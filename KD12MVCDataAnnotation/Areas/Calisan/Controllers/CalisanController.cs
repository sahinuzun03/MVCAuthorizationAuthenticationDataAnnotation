using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KD12MVCDataAnnotation.Areas.Calisan.Controllers
{
    //Admin'de Çalışan'a ait controller üzerinden verilere ulaşmasını sağladım.
    [Authorize(Roles = "Calisan,Admin")]
    public class CalisanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
