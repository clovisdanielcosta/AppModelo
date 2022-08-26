using CD.UI.Site.Models;
using Microsoft.EntityFrameworkCore;

namespace CD.UI.Site.Data
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
    }
}
