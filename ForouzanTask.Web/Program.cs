using ForouzanTask.Application;
using ForouzanTask.DataLayer.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
#region Services

builder.Services.AddControllersWithViews();

#region DbContext

builder.Services.AddDbContext<ForouzanTaskContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ForouzanTaskConnection"))
);

#endregion

#region Authentication

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = "/Login";
    options.LogoutPath = "/Logout";
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
});

#endregion

#region Encode

builder.Services.AddSingleton<HtmlEncoder>(
    HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));

#endregion

#region Register Dependencies

ApplicationServicesRegistration.ConfigureApplicationServices(builder.Services);

#endregion

#region Minify

//builder.Services.AddWebMarkupMin(
//        options =>
//        {
//            options.AllowMinificationInDevelopmentEnvironment = true;
//            options.AllowCompressionInDevelopmentEnvironment = true;
//        })
//    .AddHtmlMinification(
//        options =>
//        {
//            options.MinificationSettings.RemoveRedundantAttributes = true;
//            options.MinificationSettings.RemoveHttpProtocolFromAttributes = true;
//            options.MinificationSettings.RemoveHttpsProtocolFromAttributes = true;
//        })
//    .AddHttpCompression();

#endregion
#endregion

var app = builder.Build();
// Configure the HTTP request pipeline.
#region PipeLines
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

#endregion



app.Run();
