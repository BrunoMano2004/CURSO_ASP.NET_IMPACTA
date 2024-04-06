using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.AspNet._05.BackEnd.WebAPI.Controllers.Data;
using Projeto.AspNet._05.BackEnd.WebAPI.Controllers.Data.Entities;

namespace Projeto.AspNet._05.BackEnd.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class JoinController : ControllerBase
    {
        private readonly MeuDbContext _dbContext;

        public JoinController(MeuDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetJoinTodosOsCursos")]

        public async Task<ActionResult> GetJoinTodos()
        {
            var cursosComEstudantes = await _dbContext.Curso.Include(cs => cs.Estudante).ToListAsync();

            return Ok(cursosComEstudantes);
        }

        [HttpGet]
        [Route("buscaFiltradaCurso")]
        public async Task<ActionResult> buscaFiltradaCurso(string termo)
        {
            var resultadoFiltrado = await _dbContext.Curso.Where(cs => cs.CursoNome.Contains(termo)).Include(t => t.Estudante).ToListAsync();

            return Ok(resultadoFiltrado);
        }

        [HttpGet]
        [Route("GetJoinTodosOsEstudantes")]
        public async Task<ActionResult<IEnumerable<Estudante>>>
            GetEstudantesComCursos()
        {
            /*
            var estudantesComCursos = await _dbContext.Estudante.Include(e => e.Curso).ToListAsync();
            return Ok(estudantesComCursos);
            */

            var estudantesComCursos = await _dbContext.Estudante.Select(
                juntando => new
                    {
                    Estudante = juntando, Cursos = _dbContext.Curso.Where(juntandoComCurso => juntandoComCurso.EstudanteId == juntando.EstudanteId).ToList()
                    }
                ).ToListAsync();
            return Ok(estudantesComCursos);
        }

        [HttpGet]
        [Route("buscaFiltradaEstudante")]
        public async Task<ActionResult> buscaFiltradaEstudante(string termo)
        {
            var resultado = await _dbContext.Estudante.Where(cs => cs.EstudanteNome.Contains(termo)).Include(t => t.Curso).ToListAsync();

            return Ok(resultado);
        }
    }
}
