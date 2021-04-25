using Microsoft.AspNetCore.Mvc;

namespace AtividadeAvaliativa.Controllers
{
    public class AjudaController : Controller
    {
        // GET
        public IActionResult Ajuda()
        {
            return View();
        }
    }
}