using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.AspNet._05.BackEnd.WebAPI.Controllers.Data;
using Projeto.AspNet._05.BackEnd.WebAPI.Controllers.Data.Entities;

namespace Projeto.AspNet._05.BackEnd.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EstudanteController : ControllerBase
    {
        private readonly MeuDbContext _dbContext;

        public EstudanteController(MeuDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetAll")]

        public async Task<ActionResult> Get()
        {
            var listaEstudantes = await _dbContext.Estudante.ToListAsync();

            return Ok(listaEstudantes);
        }

        [HttpGet]
        [Route("GetOne/{id}")]

        public async Task<ActionResult> GetOne(int id)
        {
            var estudanteUnico = await _dbContext.Estudante.FindAsync(id);

            if (estudanteUnico == null)
            {
                return NotFound();
            }

            return Ok(estudanteUnico);
        }
        [HttpPost]
        [Route("AdicRegistro")]

        public async Task<ActionResult> Post(Estudante registro)
        {
            _dbContext.Estudante.Add(registro);

            await _dbContext.SaveChangesAsync();

            return Ok(registro);
        }
        [HttpPut]
        [Route("UpRegister/{id}")]

        public async Task<ActionResult> PutRegister([FromRoute] int id, Estudante novoRegistro)
        {
            var buscandoEstudante = await _dbContext.Estudante.FindAsync(id);

            if (buscandoEstudante == null)
            {
                return NotFound();
            }
            buscandoEstudante.EstudanteNome = novoRegistro.EstudanteNome;
            buscandoEstudante.EstudanteSobrenome = novoRegistro.EstudanteSobrenome;
            buscandoEstudante.EstudanteRA = novoRegistro.EstudanteRA;
            buscandoEstudante.EstudanteEmail = novoRegistro.EstudanteEmail;
            buscandoEstudante.EstudanteIdade = novoRegistro.EstudanteIdade;
            buscandoEstudante.EstudanteFone = novoRegistro.EstudanteFone;
            buscandoEstudante.EstudanteGenero = novoRegistro.EstudanteGenero;

            await _dbContext.SaveChangesAsync();

            return Ok(buscandoEstudante);
        }

        // 1º passo: fazer uso do atributo [HttpDelete] de maneira direta para excluir um registro da base
        [HttpDelete]

        // 2º passo: definir a rota especifica para que o registro seja, devidamente, identificado e possa, dessa forma, ser excluido
        [Route("delRegister/{id}")]

        // 3º passo: definir a tarefa assincrona
        public async Task<ActionResult> Delete(int id)
        {
            // 4º passo: definir uma prop para receber como valor a consulta à base para identificar e recuperar o registros devidamente selecionado
            var excluirRegistro = await _dbContext.Estudante.FindAsync(id);

            // 5º passo: verificar se o registro foi encontrado
            if (excluirRegistro == null)
            {
                return NotFound();
            }

            // 6º passo: se o registro, realmente, existe será excluido
            _dbContext.Estudante.Remove(excluirRegistro); // neste momento, o registro é excluido

            // 7º passo: "salvando" as alterações
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
