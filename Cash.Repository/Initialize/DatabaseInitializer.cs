using Cash.Core.Enums;
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
                    FullName = "Fatma Mutlu",
                    UserName = "fatmamutlu",
                    Password = "123",
                });
                await _appDbContext.Users.AddAsync(new()
                {
                    FullName = "Erkan Bostan",
                    UserName = "erkanbstn",
                    Password = "123",
                });
                await _appDbContext.Users.AddAsync(new()
                {
                    FullName = "Büşra Hekimoğlu",
                    UserName = "busrahekim",
                    Password = "123",
                });
                await _appDbContext.Banks.AddAsync(new()
                {
                    Name = "Halk Bank",
                    ExchangeType = ExchangeEnum.Euro
                });
                await _appDbContext.Banks.AddAsync(new()
                {
                    Name = "Ziraat Bank",
                    ExchangeType = ExchangeEnum.TurkishLira
                });
                await _appDbContext.Banks.AddAsync(new()
                {
                    Name = "Garanti Bank",
                    ExchangeType = ExchangeEnum.Sterlin
                });
                await _appDbContext.SaveChangesAsync();
                await _appDbContext.Accounts.AddAsync(new()
                {
                    No = "4000500060007000",
                    Balance = 15000,
                    BankId = 1,
                    UserId = 1,
                });
                await _appDbContext.Accounts.AddAsync(new()
                {
                    No = "1000200030008000",
                    Balance = 15000,
                    BankId = 2,
                    UserId = 2,
                });
                await _appDbContext.Accounts.AddAsync(new()
                {
                    No = "2000300070004000",
                    Balance = 15000,
                    BankId = 3,
                    UserId = 3,
                });
                await _appDbContext.SaveChangesAsync();
                await _appDbContext.Processes.AddAsync(new()
                {
                    SenderId = 1,
                    ReceiverId = 2,
                    Amount = 150,
                    Type = ProcessEnum.Transfer
                });
                await _appDbContext.Processes.AddAsync(new()
                {
                    SenderId = 2,
                    ReceiverId = 1,
                    Amount = 250,
                    Type = ProcessEnum.Eft
                });
                await _appDbContext.Processes.AddAsync(new()
                {
                    SenderId = 3,
                    ReceiverId = 1,
                    Amount = 250,
                    Type = ProcessEnum.Transfer
                });
                await _appDbContext.Processes.AddAsync(new()
                {
                    SenderId = 1,
                    ReceiverId = 3,
                    Amount = 250,
                    Type = ProcessEnum.Eft
                });
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}