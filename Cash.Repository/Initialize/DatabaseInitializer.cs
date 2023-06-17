using Cash.Repository.DataAccess;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Cash.Repository.Initialize
{
    public class DatabaseInitializer
    {
        // AppDbContext Instance

        private readonly AppDbContext _appDbContext;

        // DatabaseInitializer Constructor

        public DatabaseInitializer(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // Initialize Database and Run Seed

        public async Task InitializeDatabase()
        {
            if (!await _appDbContext.GetService<IDatabaseCreator>().CanConnectAsync())
            {
                // Auto Migrate on Database

                // _context.Database.Migrate();
                //  await _context.Database.MigrateAsync();

                // Auto Create or Delete Database

                await _appDbContext.Database.EnsureDeletedAsync();
                await _appDbContext.Database.EnsureCreatedAsync();

                // Seed Data

                await _appDbContext.Users.AddAsync(new()
                {
                    FullName = "Erkan Bostan",
                    UserName = "erkanbstn",
                    Password = "123",
                });
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}