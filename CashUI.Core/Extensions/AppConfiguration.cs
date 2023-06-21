using Cash.Repository.DataAccess;
using Cash.Repository.Initialize;
using Cash.Repository.Interfaces;
using Cash.Service.Managers;
using Cash.Service.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

namespace CashUI.Core.Extensions
{
    public static class AppConfiguration
    {
        // Container Dependencies
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Database Initializer Transient

            services.AddTransient<DatabaseInitializer>();

            // Authentication Configuration

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(x => { x.LoginPath = "/Auth/SignIn"; });

            // Context Configuration

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Sql"));
            });

            // Default Mvc Configuration

            services.AddControllersWithViews();

            // Auto Mapper Configuration

            services.AddAutoMapper(typeof(Program));

            // Configure Interfaces Dependencies

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserManager>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountManager>();

            services.AddScoped<IProcessRepository, ProcessRepository>();
            services.AddScoped<IProcessService, ProcessManager>();
        }

        // App Dependencies
        public static WebApplication ConfigureApp(this WebApplication app)
        {
            // Database Initializer Run

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var initialiser = services.GetRequiredService<DatabaseInitializer>();
                initialiser.InitializeDatabase().Wait();
            }


            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Error Page Configuration

            app.UseStatusCodePages();
            app.UseStatusCodePagesWithReExecute("/Auth/Error", "?code={0}");

            // Default Configuration
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            // Authenticaton Configuration
            app.UseAuthentication();
            app.UseAuthorization();

            // Default Controllers
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Auth}/{action=SignIn}/{id?}");

            // Area Controllers
            app.MapControllerRoute(
               name: "areas",
                  pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

            app.Run();

            return app;
        }
    }
}
