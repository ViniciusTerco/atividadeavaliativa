using Microsoft.AspNetCore.Mvc;

namespace AtividadeAvaliativa.Controllers.Admin
{
    public class SupervisaoController : AdminController
    {
        // GET
        public IActionResult Index()
        {
            return View(NomeDaView());
        }
    }
}