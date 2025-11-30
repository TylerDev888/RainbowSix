using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RainbowSix.Common;
using RainbowSix.Common.Database;
using RainbowSix.Common.Database.Dtos;
using RainbowSix.Common.Database.Entities;
using RainbowSix.Common.Database.Mappers;
using RainbowSix.Common.Database.Migrations;
using RainbowSix.Common.Database.Services;
using RainbowSix.Common.Interfaces;
using RainbowSix.Common.Models.Response;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RainbowSix.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // 1. Build configuration (reads from appsettings.json or env vars)
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // 2. Setup DI container
            var services = new ServiceCollection();

            services.AddDbContext<RainbowSixDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            var serviceProvider = services.BuildServiceProvider();

            var logger = new ConnectionLogger();

            var db = serviceProvider.GetRequiredService<RainbowSixDbContext>();

            var nodes = await db.Nodes
                .Include(n => n.Item)
                    .ThenInclude(i => i.Tags)
                .Include(n => n.MarketData)
                    .ThenInclude(md => md.LastSoldAt)
                .Include(n => n.MarketData)
                    .ThenInclude(md => md.Stats)
                .Include(n => n.Viewer)
                    .ThenInclude(v => v.Meta)
                        .ThenInclude(vm => vm.ActiveTrade)
                            .ThenInclude(t => t.PaymentOptions)
                .Include(n => n.Viewer)
                    .ThenInclude(v => v.Meta)
                        .ThenInclude(vm => vm.ActiveTrade)
                            .ThenInclude(t => t.TradeItems)
                .ToListAsync();


            var json = JsonSerializer.Serialize(nodes);

            File.WriteAllText("C:\\\\Temp\\weaponData.json", json);

            PrintMarketplaceReport(nodes);
        }

        public async Task RunDbSync()
        {
            // 1. Build configuration (reads from appsettings.json or env vars)
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // 2. Setup DI container
            var services = new ServiceCollection();

            services.AddDbContext<RainbowSixDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            var serviceProvider = services.BuildServiceProvider();

            var logger = new ConnectionLogger();

            var username = configuration["Credentials:Username"] ?? "";
            var password = configuration["Credentials:Password"] ?? "";

            var db = serviceProvider.GetRequiredService<RainbowSixDbContext>();
            var sessionStore = new UbisoftSessionDbStore(db);
            var rainbowSixConnection = new UbisoftConnection(logger, sessionStore);
            var mapper = new MappingService();
            var marketService = new RainbowSixMarketService(db, mapper);

            IUbisoftSession session = await rainbowSixConnection.Authenticate(username, password, () =>
            {
                logger.WriteLine("Ubisoft is requesting a 2fa code please enter it now");
                return Console.ReadLine() ?? string.Empty;
            });

            int page = 216;
            const int pageSize = 40;
            bool moreItems = true;

            while (moreItems)
            {
                logger.WriteLine($"Fetching buyable items: page {page + 1}");

                var response = await rainbowSixConnection.GetBuyableItemsAsync(session, pageSize, page * pageSize);

                if (response == null || response.Nodes == null || !response.Nodes.Any())
                {
                    moreItems = false;
                    logger.WriteLine("No more buyable items found.");
                }
                else
                {
                    logger.WriteLine($"Fetched [page:{page}] count:{response.Nodes.Count}");
                    var nodeDtos = mapper.Map<List<NodeDto>>(response.Nodes);
                    await marketService.SaveMarketableItemsBulkAsync(nodeDtos);
                    page++;
                    await Task.Delay(2000);
                }
            }

            Console.WriteLine($"Completed with {page}");
        }

        static void PrintMarketplaceReport(List<Common.Database.Entities.Node> nodes)
        {
            if (nodes == null || nodes.Count == 0)
            {
                Console.WriteLine("No items found in the marketplace.");
                return;
            }

            int totalItems = nodes.Count;
            int totalInventoryValue = 0;
            int totalSaleOrders = 0;
            int totalPurchaseOrders = 0;
            int overallMinPrice = int.MaxValue;
            int overallMaxPrice = int.MinValue;

            foreach (var node in nodes)
            {
                if (node.MarketData == null || node.Item == null)
                    continue;

                var sell = node.MarketData.Stats?.FirstOrDefault(s => s.StatType.ToString() == "Sell");
                var buy = node.MarketData.Stats?.FirstOrDefault(s => s.StatType.ToString() == "Buy");
                var lastSold = node.MarketData.LastSoldAt?.LastOrDefault();

                if (sell == null || buy == null || lastSold == null)
                    continue;

                int currentMin = sell.LowestPrice;
                int currentMax = sell.HighestPrice;
                int lastPrice = lastSold.Price;
                int saleOrders = sell.ActiveCount;
                int purchaseOrders = buy.ActiveCount;

                totalInventoryValue += lastPrice;
                totalSaleOrders += saleOrders;
                totalPurchaseOrders += purchaseOrders;
                overallMinPrice = Math.Min(overallMinPrice, currentMin);
                overallMaxPrice = Math.Max(overallMaxPrice, currentMax);

                double percentChange = lastPrice > 0
                    ? ((double)(currentMin - lastPrice) / lastPrice) * 100
                    : 0;

                // === Print in Rainbow Six format ===
                Console.WriteLine(node.Item.Name?.ToUpperInvariant());
                Console.WriteLine();
                Console.WriteLine("Current price range");
                Console.WriteLine($"{currentMin} - {currentMax}");
                Console.WriteLine();
                Console.WriteLine($"{percentChange:+0.0;-0.0}%");
                Console.WriteLine();
                Console.WriteLine($"{lastPrice}");
                Console.WriteLine("Purchase order");

                Console.WriteLine(node.Viewer?.Meta?.ActiveTrade != null
                    ? "You already own this item"
                    : "You do not own this item");

                Console.WriteLine();
                Console.WriteLine($"Sale orders");
                Console.WriteLine(saleOrders);
                Console.WriteLine($"Purchase orders");
                Console.WriteLine(purchaseOrders);

                Console.WriteLine();
                Console.WriteLine("Item details");
                Console.WriteLine(node.Item.Type?.ToUpperInvariant());

                // rarity_xxx tag
                var rarity = node.Item.Tags?.FirstOrDefault(tag => tag.Value.StartsWith("rarity_"));
                if (rarity != null)
                    Console.WriteLine($"RARITY: {rarity.Value.Replace("rarity_", "").ToUpper()}");

                // all other tags
                var otherTags = node.Item.Tags?
                    .Where(t => t.Value != null && !t.Value.StartsWith("rarity_"))
                    .Select(t => t.Value)
                    .ToList();

                if (otherTags != null && otherTags.Count > 0)
                    Console.WriteLine($"Tags: {string.Join(", ", otherTags)}");

                Console.WriteLine();
                Console.WriteLine("Last sold at");
                Console.WriteLine(lastPrice);

                Console.WriteLine("===========================================");
            }

            // === Summary ===
            Console.WriteLine("=== MARKET SUMMARY ===");
            Console.WriteLine($"Total items: {totalItems}");
            Console.WriteLine($"Total inventory value (based on last sold): {totalInventoryValue}");
            Console.WriteLine($"Overall min price: {overallMinPrice}");
            Console.WriteLine($"Overall max price: {overallMaxPrice}");
            Console.WriteLine($"Total sale orders: {totalSaleOrders}");
            Console.WriteLine($"Total purchase orders: {totalPurchaseOrders}");
            Console.WriteLine("======================");
        }

    }
}
