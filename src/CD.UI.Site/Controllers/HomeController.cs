using CD.UI.Site.Data;
using Microsoft.AspNetCore.Mvc;

namespace CD.UI.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;

        public HomeController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public IActionResult Index()
        {
            var pedido = _pedidoRepository.ObterPedido();

            return View();
        }

        /*Outra maneira de injetar dependência quando não se pode criar o construtor
        public IActionResult Index([FromServices] IPedidoRepository pedidoRepository)
        {
            var pedido = _pedidoRepository.ObterPedido();

            return View();
        } */
    }
}
