using RainbowSix.Common.Enums;
using RainbowSix.Common.Models;
using RainbowSix.Common.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowSix.Common
{
    public static class GraphQLBuilder
    {
        public static GraphQLRequest<QueryMarketPlaceItemsVariables> QueryMarketPlaceItems (
            MarketPlaceItemQueryType queryType,
            int limit = 50, 
            int offset = 0)
        {
            var operationName = "";
            var orderType = "";
            var query = "";

            switch (queryType)
            {
                case MarketPlaceItemQueryType.Buy:
                    operationName = "GetMarketableItems";
                    query = GraphQLQueries.GetMarketableItems;
                    orderType = "Sell";
                    break;
                case MarketPlaceItemQueryType.Sell:
                    operationName = "GetSellableItems";
                    query = GraphQLQueries.GetSellableItems;
                    orderType = "Buy";
                    break;
                case MarketPlaceItemQueryType.TransactionsPending:
                    operationName = "GetTransactionsPending";
                    query = GraphQLQueries.GetTransactionPending;
                    break;
                case MarketPlaceItemQueryType.TransactionsHistory:
                    operationName = "GetTransactionsHistory";
                    query = GraphQLQueries.GetTransactionHistory;
                    break;
            }

            var collectionQuery = new GraphQLRequest<QueryMarketPlaceItemsVariables>
            {
                OperationName = operationName,
                Variables = new QueryMarketPlaceItemsVariables
                {
                    SpaceId = UbisoftVariables.SpaceId.ToString(),
                    Limit = limit,
                    Offset = offset,
                    WithOwnership = false
                },
                Query = query
            };

            if(queryType == MarketPlaceItemQueryType.Buy || queryType == MarketPlaceItemQueryType.Sell)
            {
                collectionQuery.Variables.SortBy = new SortBy
                {
                    Field = "ACTIVE_COUNT",
                    Direction = "DESC",
                    OrderType = orderType,
                    PaymentItemId = UbisoftVariables.PaymentItemId.ToString()
                };
            }

            return collectionQuery;
        }
        public static GraphQLRequest<GetBalanceVariables> GetBalance(string itemId)
            => new GraphQLRequest<GetBalanceVariables>
            {
                OperationName = "GetBalance",
                Variables = new GetBalanceVariables
                {

                    SpaceId = UbisoftVariables.SpaceId.ToString(),
                    ItemId = itemId
                },
                Query = GraphQLQueries.GetBalance
            };
    }
}
