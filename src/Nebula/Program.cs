using Microsoft.AspNetCore.Authentication.Cookies;
using Nebula.Domain.Abstractions.Services;
using Nebula.Services;

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

    builder.Services.AddHttpContextAccessor();
    
    builder.Services.AddSingleton<IAuthorizationService, AuthorizationService>();
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