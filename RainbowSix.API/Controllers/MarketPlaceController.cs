using Microsoft.AspNetCore.Mvc;
using RainbowSix.Common;
using RainbowSix.Common.Database.Dtos;
using RainbowSix.Common.Database.Mappers;
using RainbowSix.Common.Database.Services;
using RainbowSix.Common.Interfaces;
using RainbowSix.WebClient.Interfaces;

namespace RainbowSix.API.Controllers
{
    [ApiController]
    [Route("api/marketplace")]
    public class MarketPlaceController : Controller
    {
        private readonly IUbisoftSessionStore _sessionStore;
        private readonly IHttpConnectionLogger _logger;
        private readonly IRainbowSixMarketService _marketService;
        private readonly IMappingService _mappingService;

        public MarketPlaceController(
            IUbisoftSessionStore sessionStore,
            IHttpConnectionLogger logger,
            IRainbowSixMarketService marketService,
            IMappingService mappingService)
        {
            _sessionStore = sessionStore;
            _logger = logger;
            _marketService = marketService;
            _mappingService = mappingService;
        }

        [HttpGet("sell")]
        public async Task<IActionResult> Sell([FromQuery] Guid sessionId, int limit = 40, int offset = 0)
        {
            var session = _sessionStore.LoadSessionBySessionId(sessionId.ToString());

            if (session != null && !session.IsSessionExpired())
            {
                using (var connection = new UbisoftConnection(_logger, _sessionStore))
                {
                    try
                    {
                        var response = await connection.GetSellableItemsAsync(session, limit, offset);

                        if(response == null || response.Nodes == null || !response.Nodes.Any())
                            return Ok(new { isSessionExpired = false, items = Array.Empty<NodeDto>() });

                        var nodeDtos = _mappingService.Map<List<NodeDto>>(response.Nodes);

                        await _marketService.SaveMarketableItemsBulkAsync(nodeDtos);
                        return Ok(new { isSessionExpired = false, items = nodeDtos });
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(new
                        {
                            message = "Sellable items could not be retrieved,",
                            errorCode = "ERROR_SELL_ITEMS",
                            exception = new
                            {
                                ex.Message,
                                ex.StackTrace // Optional: remove in production for security
                            }
                        });
                    }
                }
            }

            return Ok(new { isSessionExpired = true, message = "Session Expired" });
        }
        
        [HttpGet("buy")]
        public async Task<IActionResult> Buy([FromQuery] Guid sessionId, int limit = 40, int offset = 0)
        {
            var session = _sessionStore.LoadSessionBySessionId(sessionId.ToString());

            if (session != null && !session.IsSessionExpired())
            {
                using (var connection = new UbisoftConnection(_logger, _sessionStore))
                {
                    try
                    {
                        var response = await connection.GetBuyableItemsAsync(session, limit, offset);

                        if (response == null || response.Nodes == null || !response.Nodes.Any())
                            return Ok(new { isSessionExpired = false, items = Array.Empty<NodeDto>() });

                        var nodeDtos = _mappingService.Map<List<NodeDto>>(response.Nodes);

                        await _marketService.SaveMarketableItemsBulkAsync(nodeDtos);
                        return Ok(new { isSessionExpired = false, items = nodeDtos });
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(new
                        {
                            message = "Buyable items could not be retrieved,",
                            errorCode = "ERROR_BUY_ITEMS",
                            exception = new
                            {
                                ex.Message,
                                ex.StackTrace // Optional: remove in production for security
                            }
                        });
                    }
                }
            }

            return Ok(new { isSessionExpired = true, message = "Session Expired" });
        }
    }

}
