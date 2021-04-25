using Microsoft.AspNetCore.Mvc;

namespace AtividadeAvaliativa.Controllers
{
    public class InformacoesLegaisController : Controller
    {
        
        public IActionResult TermoDeUso()
        {
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }
    }
}