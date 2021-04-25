using Microsoft.AspNetCore.Mvc;

namespace AtividadeAvaliativa.Controllers.Admin
{
    public class AdminController : Controller
    {

        public string NomeDaView(string viewName = null)
        {
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;
            viewName ??= ControllerContext.ActionDescriptor.ActionName;
            return "~/View/Admin/" + controllerName + "/" + viewName + ".cshtml";
        }
        
    }
}