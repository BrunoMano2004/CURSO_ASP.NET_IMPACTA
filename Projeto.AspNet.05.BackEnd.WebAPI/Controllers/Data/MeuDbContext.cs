using Microsoft.EntityFrameworkCore;

namespace Projeto.AspNet._05.BackEnd.WebAPI.Controllers.Data
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base (options) { }

        public DbSet<Entities.Estudante> Estudante { get; set; }

        public DbSet<Entities.Curso> Curso { get; set; }
    }
}
