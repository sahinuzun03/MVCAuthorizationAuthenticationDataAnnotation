using KD12MVCDataAnnotation.Areas.Admin.Models.ViewModel;
using KD12MVCDataAnnotation.Contexts;
using KD12MVCDataAnnotation.Models;
using KD12MVCDataAnnotation.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KD12MVCDataAnnotation.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly HastaneDbContext _hastaneDbContext;

        public AdminController(HastaneDbContext hastaneDbContext)
        {
            _hastaneDbContext = hastaneDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CalisanEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalisanEkle(CalisanEkleVM calisanEkleVM)
        {
            if (ModelState.IsValid)
            {
                Calisan calisan = new Calisan();
                calisan.Ad = calisanEkleVM.KullaniciAdi;
                calisan.Soyad = calisanEkleVM.KullaniciSoyadi;
                calisan.Sifre = calisanEkleVM.KullaniciSifre;
                calisan.EmailAdress = calisanEkleVM.KullaniciMail;
                calisan.DogumTarihi = calisanEkleVM.KullaniciDogumTarihi;

                _hastaneDbContext.Calisans.Add(calisan);
                _hastaneDbContext.SaveChanges();

                return RedirectToAction("CalisanListele");
            }
            return View();
        }

        public IActionResult CalisanListele()
        {
            return View(_hastaneDbContext.Calisans.ToList());
        }
    }
}
