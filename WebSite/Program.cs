using GoogleReCaptcha.V3;
using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using WebSite;
using WebSite.Core.Services;
using WebSite.DataLayer.Context;
using WebSite.DataLayer.Ioc;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMvc();
builder.Services.AddMvcCore();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<ICaptchaValidator, GoogleReCaptchaValidator>();
builder.Services.AddSingleton<HtmlEncoder>(
    HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin,
        UnicodeRanges.Arabic }));


#region authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;

}).AddCookie(options =>
{
    options.SlidingExpiration = false;
    options.LoginPath = "/login";
    options.LogoutPath = "/logout";
    //options.AccessDeniedPath = new PathString("/Home/Forbidden/");
    options.Cookie.Name = ".my.dreamland2000.ir.cookie";
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.Events = new CookieAuthenticationEvents
    {
        OnValidatePrincipal = context =>
        {
            var cookieValidatorService = context.HttpContext.RequestServices.GetRequiredService<ICookieValidatorService>();
            return cookieValidatorService.ValidateAsync(context);
        }
    };
});
#endregion

#region DbContext
builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionString"))
);
#endregion


#region Ioc
DependencyContainer.RegisterDependencies(builder.Services);
#endregion

#region Middleware

var app = builder.Build();
// Configure the HTTP request pipeline.


if (!app.Environment.IsDevelopment())
{
    //https redirect 
    var options = new RewriteOptions();
    options.AddRedirectToHttps();
    options.Rules.Add(new RedirectToWwwRule());
    app.UseRewriter(options);
    app.UseHttpsRedirection();

    app.UseExceptionHandler("/error");

    app.Use(async (ctx, next) =>
    {
        await next();
        if (ctx.Response.StatusCode == 404 && !ctx.Response.HasStarted)
        {
            ctx.Request.Path = "/notfound";
            await next();
        }

        if (ctx.Response.StatusCode == 500 && !ctx.Response.HasStarted)
        {
            ctx.Request.Path = "/error";
            await next();
        }
    });
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = context =>
    {
        // Cache static file for 1 year
        if (!string.IsNullOrEmpty(context.Context.Request.Query["v"]))
        {
            context.Context.Response.Headers.Add("cache-control", new[] { "public,max-age=31536000" });
            context.Context.Response.Headers.Add("Expires", new[] { DateTime.UtcNow.AddYears(1).ToString("R") }); // Format RFC1123
        }
    }
});

//app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

#endregion  


