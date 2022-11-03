using KD12MVCDataAnnotation.Contexts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using KD12MVCDataAnnotation.Models.Enums;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace KD12MVCDataAnnotation.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly HastaneDbContext _hastaneDbContext;
        public LoginController(HastaneDbContext hastaneDbContext)
        {
            _hastaneDbContext = hastaneDbContext;
        }
        public IActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GirisYap(string EmailAdres, string Password)
        {
            var girisYapanKisi = _hastaneDbContext.Calisans.Where(x => x.EmailAdress == EmailAdres && x.Sifre == Password).FirstOrDefault();
            var claims = new List<Claim>(); 
            //İstek Yapan Kişiyi Doğrulamak İçin Ondan Talep edeceğimiz Şey. 
            //Buradaki yapıda bize istek atan kişinin rolüne göre karşılama yapacağız
            //Key value şeklinde veri tutmamı sağlıyor
            //Rollerin dışında giriş yapan kullanıcılar hakkında bilgi tutmamızı sağlar


            if (girisYapanKisi != null)
            {
                if (girisYapanKisi.Role == Roles.Admin)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                }
                if (girisYapanKisi.Role == Roles.Calisan)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Calisan"));
                }
                if (girisYapanKisi.Role == Roles.Yonetici)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                }
                var userIdentity = new ClaimsIdentity(claims, "Login"); 
                //Burada bana giriş yapan kullanıcıyı temsil etmemi sağlıyor.
                //Claim identity ise sizin kimlik kartınız ise claimslar'da kimlk üzerinde bulunan bilgilerinizi ifade eder.
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity); 
                //Bizim kişimize ait olan eişilebilir koleksiyonu ifade ediyor
                //Burada da istek yapan kişiye ait bilgilerin tutulması birden fazla kişi giriş yaparsa gibi düşünebilirisiniz

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                if (girisYapanKisi.Role == Roles.Admin)
                {
                    return RedirectToAction("Index", "Admin", new { area = "Admin" });
                }
                if (girisYapanKisi.Role == Roles.Yonetici)
                {
                    return RedirectToAction("Index", "Yonetici", new { area = "Yonetici" });
                }
                if (girisYapanKisi.Role == Roles.Calisan)
                {
                    return RedirectToAction("Index", "Person", new { area = "Person" });
                }
            }
            return View();
        }

        public IActionResult CikisYap()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //HttpContext.Response.Cookies.Delete(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("GirisYap");
        }

    }
}
