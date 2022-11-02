using KD12MVCDataAnnotation.Contexts;
using KD12MVCDataAnnotation.Models.SeedData;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HastaneDbContext>
    (options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("KD12DataAnnotationConnectionString"));
    });

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    x =>
    {
        x.LoginPath = "/Login/GirisYap";
        x.Cookie = new CookieBuilder
        {
            Name = "Kd12Cookie",
            SecurePolicy = CookieSecurePolicy.Always, //Http isteklerinde eri�ilebilir yapt�k
            HttpOnly = true, //K�t� niyetli insanlar�n client-side taraf�ndan cookie eri�imi kapat�ld�

        };
        x.ExpireTimeSpan = TimeSpan.FromSeconds(20); //Ezilme durumuna kar��l�k tekrardan s�resini veriyoruz.
        x.SlidingExpiration = true; //istek gelirse tekrardan cookie s�resi uzayacak
        x.Cookie.MaxAge = x.ExpireTimeSpan;
       
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

SeedData.Seed(app);
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
            name: "Calisan",
            areaName: "Calisan",
            pattern: "Calisan/{controller=Calisan}/{action=Index}/{id?}");

    endpoints.MapAreaControllerRoute(
                name: "Admin",
                areaName: "Admin",
                pattern: "Admin/{controller=Admin}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
