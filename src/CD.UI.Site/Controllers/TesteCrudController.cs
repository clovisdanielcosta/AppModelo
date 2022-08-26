using CD.UI.Site.Data;
using CD.UI.Site.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CD.UI.Site.Controllers
{
    public class TesteCrudController : Controller
    {
        private readonly MeuDbContext _contexto;

        public TesteCrudController(MeuDbContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            var aluno = new Aluno() 
            { 
                Nome = "Daniel Costa",
                DataNascimento = DateTime.Now,
                Email = "danielc@hotmail.com"
            };

            _contexto.Alunos.Add(aluno);
            _contexto.SaveChanges();

            var alunoBuscaPorId = _contexto.Alunos.Find(aluno.Id);

            var alunoBuscaPorEmail = _contexto.Alunos.FirstOrDefault(a => aluno.Email == "danielc@hotmail.com");

            return View();
        }
    }
}
