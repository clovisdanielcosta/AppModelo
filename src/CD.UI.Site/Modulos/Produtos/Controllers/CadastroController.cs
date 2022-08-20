using Microsoft.AspNetCore.Mvc;

namespace CD.UI.Site.Modulos.Produtos.Controllers
{
    [Area("Produtos")]
    public class CadastroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("produtos/busca")]
        public IActionResult Busca()
        {
            return View();
        }
    }
}