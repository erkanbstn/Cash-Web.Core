using Cash.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Cash.Repository.DataAccess
{
    public class AppDbContext : DbContext
    {
        // Context Constructor

        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Process>().HasOne(x => x.SenderPrc).WithMany(y => y.SenderAcc).HasForeignKey(z => z.SenderId).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Process>().HasOne(x => x.ReceiverPrc).WithMany(y => y.ReceiverAcc).HasForeignKey(z => z.ReceiverId).OnDelete(DeleteBehavior.ClientSetNull);
            base.OnModelCreating(modelBuilder);
        }
        // DbSets for Entities

        public DbSet<Bank> Banks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Process> Processes { get; set; }
    }
}
