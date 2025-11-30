using Microsoft.EntityFrameworkCore;
using RainbowSix.Common.Database.Dtos;
using RainbowSix.Common.Database.Entities;
using RainbowSix.Common.Database.Mappers;

namespace RainbowSix.Common.Database.Services
{
    public class RainbowSixMarketService : IRainbowSixMarketService
    {
        private readonly RainbowSixDbContext _dbContext;
        private readonly IMappingService _mapper;

        public RainbowSixMarketService(RainbowSixDbContext dbContext, IMappingService mapping)
        {
            _dbContext = dbContext;
            _mapper = mapping;
        }

        public async Task SaveMarketableItemsBulkAsync(IEnumerable<NodeDto> marketItemDtos)
        {
            if (marketItemDtos == null) return;

            foreach (var dto in marketItemDtos)
            {
                var nodeEntity = await _dbContext.Nodes
                    .Include(n => n.Item)
                    .Include(n => n.MarketData).ThenInclude(md => md.Stats)
                    .Include(n => n.MarketData).ThenInclude(md => md.LastSoldAt)
                    .Include(n => n.Viewer).ThenInclude(v => v.Meta)
                    .FirstOrDefaultAsync(n => n.Id == dto.Id);

                if (nodeEntity == null)
                {
                    // New node → just map from DTO and add
                    nodeEntity = _mapper.Map<Node>(dto);
                    _dbContext.Nodes.Add(nodeEntity);
                }
                else
                {
                    // Existing node → update its values in-place
                    _mapper.Map(dto, nodeEntity);
                }
            }

            await _dbContext.SaveChangesAsync();
        }

    }
}
