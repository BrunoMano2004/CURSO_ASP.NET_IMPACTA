using Microsoft.AspNetCore.Mvc;
using Projeto.AspNet._04.API.BackEnd.Models;

namespace Projeto.AspNet._04.API.BackEnd.Controllers
{
    [Route("api/[controller]")] // indicar - quando necessário - o "caminho/rota" pelo qual o conjunto de requisições
                                // http estabelecerá para o conjunto de dados
                                // aqui, o atributo [route] indica/define qual a rota que deve ser acessada para o 
                                // funcionamento da api


    [ApiController] // Ete é o atributo que define o papel deste controller para a aplicação - see uma web api. Esta será uma restFULL.
    // serão usadas requisições http para acesso à estrutura de armazenamento.
    public class ReservasController : ControllerBase // a prática do mecanismo de herança com a super classe ControllerBase é exercida
                                                     // para esta parte do projeto - para que sejam acessados os recursos necessários
                                                     // para a operação com os dados a partir de uma api: significa que esta classe
                                                     // NÃO se relaciona com views
    {
        // Definir os recursos que seão usados para as operações de dados

        // 1 passo: Criar um objeto referencial para lidar com as instruções CRUD. Dessa forma, será útil fazer uso deste objeto
        // para auxiliar na construção das operações de dados.
        private IRepository _repositorio;

        // 2 passo: Definir agora, o construtor da classe para gerar a injeção de dependencia fazendo uso do objeto referencial - criado acima
        public ReservasController(IRepository repositorio) =>  _repositorio = repositorio;

        /*==================================================================================================================================
         * IMPLEMENTAÇÃO DE DADOS - BASEADO NO CRUD
         *=================================================================================================================================
         */

        // 1 passo: implementação da requisição GET - operação para recuperar todos os dados da base
        [HttpGet]
        public IEnumerable<Reserva> Get() => _repositorio.Reservas;

        // 2 passo: implementação da requisição GET - operação para recuperar um único registro da base - desde que esteja devidamente identificado

        [HttpGet("{id}")]
        public ActionResult<Reserva> Get(int id)
        {
            // avaliar se o registro seleciona, realmente, existe
            if(id == 0)
            {
                return BadRequest("Algum valor de identificador de ser passado como elemento da requisição");
            }
            return Ok(_repositorio[id]);
        }
        // 3 passo: implementação da requisição update - operação para recuperar um registro da base e, se necessário, alterar/atualizar seus valores.
        // Para este propósito será usado o atributo de requisição [HttpPost] 
        [HttpPost]

        // A criação de um novo registro - a partir do atributo de requisição [FromBody] indica o local onde um valor para um parametro qualquer deve
        // ser obtido. Qual é o local onde se encontram os valores da requisição? R: No corpo(body) desta mesma requisição
        public Reserva Post([FromBody] Reserva atualizarRegistro) => _repositorio.AddReserva(new Reserva
        {
            Nome = atualizarRegistro.Nome,
            Sobrenome = atualizarRegistro.Sobrenome,
            PontoA = atualizarRegistro.PontoA,
            PontoB = atualizarRegistro.PontoB,
            DataChegada = atualizarRegistro.DataChegada,
            DataPartida = atualizarRegistro.DataPartida,
            EnderecoHospedagem = atualizarRegistro.EnderecoHospedagem
        });

        // 4 passo: implementação da requisição de atualização

        [HttpPut] // atributo de requisição responsável por possibilitar a alteração/atualização de registro - devidamente identificado na base

        // Ao utilizar o atributo [FromForm] a obtenção dos dados terá origem num formulário front-end
        public Reserva Put([FromForm] Reserva registroAlt) => _repositorio.UpdateReserva(registroAlt);

        [HttpDelete]
        public void Delete(int id) => _repositorio.DeleteReserva(id);

    }
}
