using RainbowSix.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowSix.Common
{
    public static class GraphQLBatchBuilder
    {
        public static List<GraphQLRequest<T>> BuildBatch<T>(params GraphQLRequest<T>[] requests)
            => requests.ToList();
    }
}
