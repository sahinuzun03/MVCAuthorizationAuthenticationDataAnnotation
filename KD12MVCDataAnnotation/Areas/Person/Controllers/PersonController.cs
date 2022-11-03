using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KD12MVCDataAnnotation.Areas.Person.Controllers
{
    [Authorize(Roles = "Calisan,Admin")]
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
