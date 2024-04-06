namespace Projeto.AspNet._05.WebAPI.Front.Models
{
    // Esta classe é o model main da aplicação front-end. Possui o mesmo nome do model main do back-end. Dessa forma, é possível 
    // estabelecer uma operação consistente para os dados que circularão pela aplicação.
    public class Reserva
    {
        // Definir as props do model
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string PontoA { get; set; }
        public string PontoB { get; set;}
        public string DataChegada { get; set; }
        public string DataPartida { get; set; }
        public string EnderecoHospedagem { get; set; }

    }
}
