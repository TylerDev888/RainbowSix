using Microsoft.EntityFrameworkCore;
using System;

namespace RainbowSix.Common.Database.Entities
{
    public class RainbowSixDbContext : DbContext
    {
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Node> Nodes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<MarketData> MarketData { get; set; }
        public DbSet<Stat> Stats { get; set; }
        public DbSet<LastSoldAt> LastSoldAt { get; set; }
        public DbSet<ViewerMeta> ViewerMetas { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<TradeItem> TradeItems { get; set; }
        public DbSet<PaymentOption> PaymentOptions { get; set; }
        public DbSet<UserGameTradesLimitations> TradesLimitations { get; set; }
        public DbSet<UserGamePurchaseLimitations> PurchaseLimitations { get; set; }
        public DbSet<UserGameSaleLimitations> SaleLimitations { get; set; }
        public DbSet<UserGameResaleLock> ResaleLocks { get; set; }

        public RainbowSixDbContext(DbContextOptions<RainbowSixDbContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Stat>()
                .Property(s => s.StatType)
                .HasConversion<string>();

            modelBuilder.Entity<Stat>()
                .HasOne(s => s.MarketData)
                .WithMany(md => md.Stats)
                .HasForeignKey(s => s.MarketDataId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LastSoldAt>()
                .HasOne(ls => ls.MarketData)
                .WithMany(md => md.LastSoldAt)
                .HasForeignKey(ls => ls.MarketDataId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Node>()
                .HasOne(n => n.Item)
                .WithMany()
                .HasForeignKey(n => n.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Node>()
                .HasOne(n => n.MarketData)
                .WithMany()
                .HasForeignKey(n => n.MarketDataId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Node>()
                .HasOne(n => n.Viewer)
                .WithMany()
                .HasForeignKey(n => n.ViewerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TradeItem>()
                .HasOne(ti => ti.Item)
                .WithMany()
                .HasForeignKey(ti => ti.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PaymentOption>()
                .HasOne(po => po.Item)
                .WithMany()
                .HasForeignKey(po => po.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserGameResaleLock>()
                .HasOne(rl => rl.SaleLimitations)
                .WithMany(sl => sl.ResaleLocks)
                .HasForeignKey(rl => rl.SaleLimitationsId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
