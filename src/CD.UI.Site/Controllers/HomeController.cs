using CD.UI.Site.Data;
using CD.UI.Site.Services;
using Microsoft.AspNetCore.Mvc;

namespace CD.UI.Site.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPedidoRepository _pedidoRepository;
        public OperacaoService OperacaoService { get; }
        public OperacaoService OperacaoService2 { get; }

        public HomeController(IPedidoRepository pedidoRepository, OperacaoService operacaoService,OperacaoService operacaoService2)
        //public HomeController(OperacaoService operacaoService, OperacaoService operacaoService2)
        {
            _pedidoRepository = pedidoRepository;
            OperacaoService2 = operacaoService;
            OperacaoService2 = operacaoService2;
        }

        ////Exempo de ciclo de vida das variáveis
        //public string Index()
        //{
        //    return
        //        "Primeira instância: " + Environment.NewLine +
        //        OperacaoService.Transient.OperacaoId + Environment.NewLine +
        //        OperacaoService.Scoped.OperacaoId + Environment.NewLine +
        //        OperacaoService.Singleton.OperacaoId + Environment.NewLine +
        //        OperacaoService.SingletonInstance.OperacaoId + Environment.NewLine +

        //        Environment.NewLine +
        //        Environment.NewLine +

        //        "Segunda instância: " + Environment.NewLine +
        //        OperacaoService2.Transient.OperacaoId + Environment.NewLine +
        //        OperacaoService2.Scoped.OperacaoId + Environment.NewLine +
        //        OperacaoService2.Singleton.OperacaoId + Environment.NewLine +
        //        OperacaoService2.SingletonInstance.OperacaoId + Environment.NewLine;
        //}

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
