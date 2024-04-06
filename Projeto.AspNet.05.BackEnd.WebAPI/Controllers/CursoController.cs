using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.AspNet._05.BackEnd.WebAPI.Controllers.Data;
using Projeto.AspNet._05.BackEnd.WebAPI.Controllers.Data.Entities;

namespace Projeto.AspNet._05.BackEnd.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CursoController : ControllerBase
    {
        private readonly MeuDbContext _dbContext;

        public CursoController(MeuDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetAll")]

        public async Task<ActionResult> Get()
        {
            var listaCursos = await _dbContext.Curso.ToListAsync();

            return Ok(listaCursos);
        }

        [HttpGet]
        [Route("GetOne/{id}")]

        public async Task<ActionResult> GetOne(int id)
        {
            var cursoUnico = await _dbContext.Curso.FindAsync(id);

            if(cursoUnico == null)
            {
                return NotFound();
            }

            return Ok(cursoUnico);
        }

        [HttpPost]
        [Route("AdicRegistro")]

        public async Task<ActionResult> Post(Curso registro)
        {
            _dbContext.Curso.Add(registro);

            await _dbContext.SaveChangesAsync();

            return Ok(registro);
        }

        [HttpPut]
        [Route("UpRegister/{id}")]

        public async Task<ActionResult> PutRegister([FromRoute] int id, Curso novoRegistro)
        {
            var buscandoCurso = await _dbContext.Curso.FindAsync(id);

            if(buscandoCurso == null)
            {
                return NotFound(id);
            }

            buscandoCurso.CursoNome = novoRegistro.CursoNome;
            buscandoCurso.CursoMensalidade = novoRegistro.CursoMensalidade;
            buscandoCurso.EstudanteId = novoRegistro.EstudanteId;
            buscandoCurso.EstudanteRA = novoRegistro.EstudanteRA;

            await _dbContext.SaveChangesAsync();
            return Ok(buscandoCurso);
        }

        [HttpDelete]
        [Route("delRegister/{id}")]

        public async Task<ActionResult> Delte(int id)
        {
            var excluirRegistro = await _dbContext.Curso.FindAsync(id);

            if(excluirRegistro == null)
            {
                return NotFound();
            }

            _dbContext.Remove(excluirRegistro);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
