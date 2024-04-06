using Microsoft.AspNetCore.Mvc;
using Projeto.AspNet._05.WebAPI.Front.Models;
using System.Diagnostics;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;
using System.Text;

namespace Projeto.AspNet._05.WebAPI.Front.Controllers
{
    // AGORA, ABAIXO SERÃO DEFINIDAS AS OPERAÇÕES - NO FRONT-END - QUE ESTABELECERÃO O FLUXO DE DADOS
    // FAZENDO USO (CONSUMINDO) DA API
    public class HomeController : Controller
    {
        public string urlAPI = "http://localhost:5150/api";
        /*
         * ================================================================================================================================
         *                          DEFINIÇÃO DAS OPERAÇÕES CRUD - NO FRONT - ACESSANDO (CONSUMINDO) A API
         *                          a ideia é que, aqui, no front os dados sejam recebidos e, posteriormente,
         *                          manipulados - de acordo com a funcionalidade de cada action
         * ================================================================================================================================
         */

        // 1º tarefa CRUD - GET: tarefa assíncrona que recupera todos os dados da estrutura de armazenamento.

        // Aqui, o atributo de requisição http é implícito [HttpGet]
        public async Task<IActionResult> Index()
        {
            // 1º passo: consiste em definir a recuperação de todos os dados da estrutura de armazenamento.
            // Para atingir este objetivo será preciso estabelecer na action a referência adequada a API que 
            // opera os dados da base.

            List<Reserva> listaReservas = new List<Reserva>();

            // 1º passo A: consiste em definir um objeto que auxilie na requisição que recuperará os dados da
            // estrutura de armazenamento
            using (var reqHttp = new HttpClient())
            {
                // "Montar" a requisição http para acessar a API e recuperar os dados da estrutura.
                using (var requisicao = await reqHttp.GetAsync(urlAPI+"/Reservas"))
                {
                    // A requisição a base se chama requisicao. Agora, é necessário acessar a requisição e observar
                    // se ocorreu a "resposta" adequada
                    string apiResposta = await requisicao.Content.ReadAsStringAsync();

                    // Estabelecer, uma vez que os dados - em tese - já foram lidos -, praticar a desserialização do conteúdo.
                    // Para este objetivo, será então, acessa a a prop/objeto listaReserva para receber como valor o conteúdo
                    // obtido da base

                    listaReservas = JsonConvert.DeserializeObject<List<Reserva>>(apiResposta);
                }
            }

                return View(listaReservas);
        }

        // 2º tarefa CRUD - Get: tarefa assíncrona que recupera um único registro da base - desde que esteja devidamente identificado

        // 1º passo: criar o retorno da view para o registro
        public ViewResult GetReserva() => View(); // Aqui, está estabelecida a view para que o registro seja acessado e, devidamente,
                                                  // selecionado, para posteriormente ser exibido na view 

        // 2º passo: Estabelecer a sobrecarga do método/action GetReserva() para a exibição do registro selecionado

        [HttpPost] // O atriburo/requisição que possibilita o envio de dados - o id - para a API. Ele está, aqui, definindo a sobrecarga
                   // GetReserva() porque será preciso enviar para/inserir um id num input de dado para, então, seleciona-lo

        public async Task<IActionResult> GetReserva(int id)
        {
            //var urlAPI = "http://localhost:5150";
            // 3º passo: gerar o objeto da classe/model Reserva
            Reserva reserva = new Reserva();

            // Praticar a instancia de HttpClient() para criar o objeto para "auxiliar" na construção da requisição de recuperação de dados selecionados
            using (var reqHttp = new HttpClient())
            {
                // 4º passo: montar a requisição
                using (var requisicao = await reqHttp.GetAsync(urlAPI + "/Reservas/" + id))
                {
                    // Acima, a requisição está montada. Agora, é necessário observar se a resposta desejada - o acesso ao registro existente
                    // e identificado - foi obtido
                    if (requisicao.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        // A requisição http se chama requisicao. Agora, é necessário fazer uso
                        string apiResposta = await requisicao.Content.ReadAsStringAsync();

                        // Estabelecer a inicialização dos dados - uma vez que, em tese, já foram recebidos no front e "lidos"
                        reserva = JsonConvert.DeserializeObject<Reserva>(apiResposta);
                    } 
                    else
                    {
                        ViewBag.StatusCode = requisicao.StatusCode;
                    }
                }
                return View(reserva);
            }
        }

        // 3º tarefa CRUD - Post: tarefa assincrona que envia dados obtidos pela view para a estrutura de armazenamento 
        // o primeiro movimento é retornar a view para que seja possivel deixa-la a disposição para a inserção de dados
        public ViewResult AddReserva() => View();

        // definir a sobrecarga do método/action para as instruções de inserção de dados
        [HttpPost] // atributo de requisição de envio de dados
        public async Task<IActionResult> AddReserva(Reserva insercaoRegistro) // Os dados obtidos pela view, ficam disponíveis no parametro
        {
            // 2º passo: gerar um objeto a partir do model para que, posteriormente, receba um determinado valor e seja retornado com a view
            Reserva reservaRecebida = new Reserva();

            // 3º passo: consiste em definir um objeto que auxiliará na construção das requisições http à base
            using (var reqHttp = new HttpClient())
            {
                // 4º passo: consiste em - uma vez que os dados foram recebidos - criar uma forma de serializar/empacotar estes dados no foramto adequado
                StringContent conteudo = new StringContent(JsonConvert.SerializeObject(insercaoRegistro), Encoding.UTF8, "application/json");

                // 5º passo: defirnir a requisição http para a chamada da API
                using (var requisicao = await reqHttp.PostAsync(urlAPI+"/Reservas", conteudo))
                {
                    //6º passo: criar uma instrução para "dar prova" que o procedimento de inserção funcionou corretamente

                    string apiResposta = await requisicao.Content.ReadAsStringAsync();

                    // acessar o objeto criado a partir da instancia do model
                    reservaRecebida = JsonConvert.DeserializeObject<Reserva>(apiResposta);
                }
            }
            return View(reservaRecebida);
        }

        // 4º tarefa CRUD - Put/Post: tarefa assincrona que envia dados otidos pela view para a estrutura de armazenamento
        // agora, este registro será gerado a partir e um já existente.

        // Primeiro movimento: retornar a view para que seja possível deixá-la a disposição para a atualização/alteração do dados

        public async Task<IActionResult> UpdateReserva(int idRegistro)
        {
            // 1º passo: para disponibilizar os dados para a view: a geração de um objeto a partir da classe model, é necessário
            // para a disposição destes na view
            Reserva dadosObtidosBase = new Reserva();

            // 2º passo: montar a requisição - a base - para que agora seja possível recuperar o registro selecionado e disponibiliza a view
            using (var reqHttp = new HttpClient())
            {
                using (var requisicao = await reqHttp.GetAsync(urlAPI+"/Reservas/"+idRegistro))
                {
                    // 4º passo: observar se a resposta da requisição foi obtida da foram deseja
                    string apiResposta = await requisicao.Content.ReadAsStringAsync();

                    // 5º passo: reformatar o conteudo para exibir na view
                    dadosObtidosBase = JsonConvert.DeserializeObject<Reserva>(apiResposta);
                }
            }
            return View(dadosObtidosBase);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReserva(Reserva DadosAtualizar)
        {
            Reserva reservaAtualizada = new Reserva();

            using (var reqHttp = new HttpClient())
            {
                var alternadoDados = new MultipartFormDataContent();

                alternadoDados.Add(new StringContent(DadosAtualizar.Id.ToString()), "Id");
                alternadoDados.Add(new StringContent(DadosAtualizar.Nome.ToString()), "Nome");
                alternadoDados.Add(new StringContent(DadosAtualizar.Sobrenome.ToString()), "Sobrenome");
                alternadoDados.Add(new StringContent(DadosAtualizar.PontoA.ToString()), "PontoA");
                alternadoDados.Add(new StringContent(DadosAtualizar.PontoB.ToString()), "PontoB");
                alternadoDados.Add(new StringContent(DadosAtualizar.DataChegada.ToString()), "DataChegada");
                alternadoDados.Add(new StringContent(DadosAtualizar.DataPartida.ToString()), "DataPartida");
                alternadoDados.Add(new StringContent(DadosAtualizar.EnderecoHospedagem.ToString()), "EnderecoHospedagem");

                using (var requisicao = await reqHttp.PutAsync(urlAPI+"/Reservas", alternadoDados))
                {
                    string apiResposta = await requisicao.Content.ReadAsStringAsync();

                    ViewBag.Result = "Success";

                    reservaAtualizada = JsonConvert.DeserializeObject<Reserva>(apiResposta);
                }
            }
            return View(reservaAtualizada);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReserva(int idRegistro)
        {
            using (var reqHttp = new HttpClient())
            {
                using (var requisicao = await reqHttp.DeleteAsync(urlAPI+"/Reservas/"+idRegistro))
                {
                    string apiResposta = await requisicao.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }
    }
}