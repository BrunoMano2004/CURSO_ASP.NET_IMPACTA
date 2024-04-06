using Projeto.AspNet._04.API.BackEnd.Models;

namespace Projeto.AspNet._04.API.BackEnd.Models
{
    // Esta interface será responsável por fazer uso do model e estabelecer os métodos de manipulação de dados
    // a partir do conceito CRUD - Create, Read, Update e Delete
    public interface IRepository
    {
        // 1 passo: os dados de registro de reserva precisam ser indicados como elementos enumeráveis
        IEnumerable<Reserva> Reservas { get; } // Esta é a instrução que recupera os dados da base -> GetAll
        
        Reserva this[int id] { get; } // Esta é a instrução que recupera um único registro de base - desde que esteja
        // devidamente identificado
        // GetOne/{Id}

        Reserva AddReserva(Reserva registroReserva); // Esta é a instrução responsável por inderir um registro na estrutura de armazenamento.

        Reserva UpdateReserva(Reserva registroAtualizado); // Esta é a instrução responsável por atualizar/alterar um registro da base.

        void DeleteReserva(int id); // Esta é a instrução responsável por excluir um registro da base - aqui, um método é definido como void
        // porque será apenas uma ação a ser executada (sem a necessidade de acessar os dados por completo; basta apenas acessar o seu elemento identificador)
    }
}
