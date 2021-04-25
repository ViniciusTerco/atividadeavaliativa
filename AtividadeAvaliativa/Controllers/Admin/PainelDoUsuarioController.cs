using Microsoft.AspNetCore.Mvc;

namespace AtividadeAvaliativa.Controllers.Admin
{
    public class PainelDoUsuarioController : AdminController
    {
        // GET
        public IActionResult Index()
        {
            return View(NomeDaView());
        }
    }
}