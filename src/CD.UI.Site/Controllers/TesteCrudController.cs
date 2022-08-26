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
                Nome = "Daniel",
                DataNascimento = DateTime.Now,
                Email = "danielc@hotmail.com"
            };

            _contexto.Alunos.Add(aluno);
            _contexto.SaveChanges();

            var alunoBuscaPorId = _contexto.Alunos.Find(aluno.Id);
            var alunoBuscaPorEmail = _contexto.Alunos.FirstOrDefault(a => a.Email == "danielc@hotmail.com");
            var listaAlunos = _contexto.Alunos.Where(a => a.Nome.Contains("Daniel"));

            aluno.Nome = "Clovis";
            _contexto.Alunos.Update(aluno);
            _contexto.SaveChanges();

            _contexto.Alunos.Remove(aluno);
            _contexto.SaveChanges();

            _contexto.Alunos.Add(aluno);
            _contexto.SaveChanges();
            var alunoASerRemovido = _contexto.Alunos.Find(aluno.Id);
            _contexto.Alunos.Remove(alunoASerRemovido);
            _contexto.SaveChanges();

            return View("_Layout");
        }
    }
}
