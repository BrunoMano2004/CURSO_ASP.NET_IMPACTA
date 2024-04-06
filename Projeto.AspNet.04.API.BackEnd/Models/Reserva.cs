namespace Projeto.AspNet._04.API.BackEnd.Models
{
    // Esta classe é o model do main da aplicação. É responsável por estabelecer o formato/regras com o qual os dados serão operados.
    public class Reserva
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? PontoA { get; set; }
        public string? PontoB { get; set; }
        public string? DataChegada { get; set; }
        public string? DataPartida { get; set; }
        public string? EnderecoHospedagem { get; set; }
    }
}
