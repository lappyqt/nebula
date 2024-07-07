using Nebula.Services;
using Nebula.Persistence;
using Microsoft.EntityFrameworkCore;
using Nebula.Domain.Abstractions.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Nebula.Domain.Abstractions;
using Nebula.Domain.Abstractions.Repositories;
using Nebula.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllersWithViews();
    builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options => {
            options.ExpireTimeSpan = TimeSpan.FromDays(20);
            options.SlidingExpiration = true;
            options.LoginPath = "/auth";
            options.Cookie.Name = "Nebula_Authorization_Details";
        });

    builder.Services.AddDataProtection();
    builder.Services.AddHttpContextAccessor();

    builder.Services.AddTransient<IUserCredentialsService, UserCredentialsService>();
    
    builder.Services.AddScoped<IPasswordRepository, PasswordRepository>();

    builder.Services.AddSingleton<IAuthorizationService, AuthorizationService>();
    builder.Services.AddScoped<IPasswordService, PasswordService>();

    builder.Services.AddDbContext<DatabaseCotnext>(options => {
        options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
    });
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
}

app.Run();