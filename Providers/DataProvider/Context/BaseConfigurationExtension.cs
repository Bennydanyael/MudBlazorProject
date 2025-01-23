using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Providers.Constant;
using Providers.DataProvider.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers.DataProvider.Context
{
    public static class BaseConfigurationExtension
    {
        public static void AddBaseDbContext(this IServiceCollection _services, IConfiguration _config)
        {
            _services.AddScoped<DbContext>(x => x.GetRequiredService<BaseDbContext>());
            _services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(
                _config.GetConnectionString("DefaultConnection"),
                o => o.MigrationsHistoryTable(tableName: HistoryRepository.DefaultTableName)));
            //builder.Services.AddIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //            .AddEntityFrameworkStores<CompanyDbContext>();
        }

        public class BaseDbContextFactory : IDesignTimeDbContextFactory<BaseDbContext>
        {
            public BaseDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<BaseDbContext>();
                optionsBuilder.UseSqlServer(PropertyConnectionString.connectionString,
                    o => o.MigrationsHistoryTable(tableName: HistoryRepository.DefaultTableName));
                return new BaseDbContext(optionsBuilder.Options);
            }
        }

        public class MigrateDatabaseCommand
        {
            private readonly IEnumerable<DbContext> _dbContexts;
            private readonly ILogger<MigrateDatabaseCommand> _logger;

            public MigrateDatabaseCommand(IEnumerable<DbContext> dbContexts, ILogger<MigrateDatabaseCommand> logger)
            {
                _dbContexts = dbContexts ?? throw new ArgumentNullException(nameof(dbContexts));
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            }

            public async Task Execute()
            {
                foreach (var dbContext in _dbContexts)
                {
                    var dbContextName = dbContext.GetType().Name;
                    _logger.LogInformation("Migrating {0}...", dbContextName);
                    await dbContext.Database.MigrateAsync();
                    _logger.LogInformation("Migration of {0} done", dbContextName);
                }
            }

        }
    }
}
