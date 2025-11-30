using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowSix.Common.Database.Mappers
{
    using AutoMapper;
    using RainbowSix.Common.Database.Dtos;
    using RainbowSix.Common.Database.Entities;
    using RainbowSix.Common.Models.Response;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // response models <--> entities 
            CreateMap<Node, NodeModel>().ReverseMap();
            CreateMap<Item, StoreItemModel>().ReverseMap();
            CreateMap<MarketData, MarketDataModel>().ReverseMap();
            CreateMap<Viewer, ViewerMetaModel>().ReverseMap();
            CreateMap<Stat, OrderStatsModel>().ReverseMap();             
            CreateMap<LastSoldAt, LastOrderStatsModel>().ReverseMap();
            CreateMap<Viewer, ViewerModel>().ReverseMap();
            CreateMap<ViewerMeta, ViewerMetaModel>().ReverseMap();
            CreateMap<Trade, TradeModel>().ReverseMap();
            CreateMap<TradeItem, TradeItemModel>().ReverseMap();


            // entities <--> dtos
            CreateMap<Node, NodeDto>().ReverseMap();
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<MarketData, MarketDataDto>().ReverseMap();
            CreateMap<Viewer, ViewerDto>().ReverseMap();
            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<Stat, StatDto>().ReverseMap();
            CreateMap<LastSoldAt, LastSoldAtDto>().ReverseMap();
            CreateMap<Viewer, ViewerDto>().ReverseMap();
            CreateMap<ViewerMeta, ViewerMetaDto>().ReverseMap();
            CreateMap<Trade, TradeDto>().ReverseMap();
            CreateMap<TradeItem, TradeItemDto>().ReverseMap();
        }
    }
}
