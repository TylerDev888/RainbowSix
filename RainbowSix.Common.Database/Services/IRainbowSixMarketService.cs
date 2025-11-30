using RainbowSix.Common.Database.Dtos;

namespace RainbowSix.Common.Database.Services
{
    public interface IRainbowSixMarketService
    {
        Task SaveMarketableItemsBulkAsync(IEnumerable<NodeDto> nodeDtos);
    }
}