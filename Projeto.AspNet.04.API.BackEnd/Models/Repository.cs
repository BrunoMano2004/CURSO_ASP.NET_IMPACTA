namespace Projeto.AspNet._04.API.BackEnd.Models
{
    // 1 passo: fazer uso do mecanismo de herança com a interface IRepository para que as instruções CRUD sejam implementadas

    // Esta classe é a estrutura de armazendamento da aplicação 
    public class Repository : IRepository
    {
        // 2 passo: definir um Dictionary - coleção de dados baseada em pares key-value(chave-valor) - para que os dados possam ser armazenados
        private Dictionary<int, Reserva> _registro;

        // 3 passo: definir o construtor da classe para qu seja possível priorizar o conteúdo que deve compor a aplicação - assim que este construtor 
        // for chamado a execução
        public Repository() 
        {
            // 4 passo: Praticar a instância direta da classe Dictionary - para o propósito de gerar (a partir dela) um objeto do qual seja possível fazer uso
            // para manipular os dados
            _registro = new Dictionary<int, Reserva>();

            // 5 passo: Será a definição de um pequeno conjunto de dados - colocados de forma inicial para compor os primeiros dados armazenados
            new List<Reserva>()
            {
                // Criar um objeto de dados para cada registro - a partir do model Reserva
                new Reserva
                {
                    Id= 1,
                    Nome = "Bruno",
                    Sobrenome = "Mano",
                    PontoA = "São Paulo - Zona Norte",
                    PontoB = "Berlim - Alemanha",
                    DataPartida = "20/12/2022",
                    DataChegada = "02/02/2023",
                    EnderecoHospedagem = "Rua Bartolomeu"
                },
                new Reserva
                {
                    Id = 2,
                    Nome = "Douglas",
                    Sobrenome = "Reis",
                    PontoA = "Santos - SP",
                    PontoB = "Berlim - Alemanha",
                    DataPartida = "30/02/2023",
                    DataChegada = "02/03/2023",
                    EnderecoHospedagem = "Rua Bartolomeu"
                },
                new Reserva
                {
                    Id = 3,
                    Nome = "Gabriela",
                    Sobrenome = "Alcaide",
                    PontoA = "Guarulhos",
                    PontoB = "Berlim - Alemanha",
                    DataPartida = "20/10/2023",
                    DataChegada = "27/10/2023",
                    EnderecoHospedagem = "Rua Dom Meinrado"
                }

            }.ForEach(res => AddReserva(res)); // Aqui, está em curso a chamada/referência do método AddReserva() - descrito na interface.
            // Agora, para que esta chamada funcione adequadamente é preciso implementar este método, ainda, na camada de repositorio.
        }// Encerra o construtor

        // 6 passo: neste passo, será acessado o objeto private _registro e referencia-lo para que seja iniciado o processo de armazenamento de registros
        // Abaixo será realizada uma verificação para observar se o objeto dictionary _registro possui uma key(chave) baseada no identificador do registro.
        // Se sim, o registro existe. Se não, então é nulo
        public Reserva this[int id] => _registro.ContainsKey(id) ? _registro[id] : null;

        // 7 passo: Agora é preciso observar se o mesmo registro - no formato dictionary - possui também uma valor associado ao elemento chave - key: value
        public IEnumerable<Reserva> Reservas => _registro.Values;
        // ***Acima, foi observado se o Dictionary está, devidamente, composto por itens baseados em pares key:value

        // 8 passo: consiste em definir/implementar as instruções que compõem o método de inserção de dados - AddReserva()
        public Reserva AddReserva(Reserva registroReserva)
        {
            // Este é o procedimento para criar o elemento identificador (KEY) associado a cada conjunto de dados (VALUE) - avaliar se o registro associado
            // ao parâmetro - não possui um identificador
            if (registroReserva.Id == 0) // True
            {
                // definir uma prop para receber como valor o objeto _registro e fazer uma contagem dos pares key:value que o compõem - se for o caso
                int key = _registro.Count;

                // Definir o instrumento lógico de incremento dos pares key:value que compõem o objeto _registro. Para este proposito será definir um loop
                // while, para que a partir do valor atribuido a var key, possa ocorrer o incremento - de uma em uma unidade
                while (_registro.ContainsKey(key))
                {
                    key++;
                }
                // O registro - em específico a prop Id de cada registro - recebe o valor do incremento da var key
                registroReserva.Id = key;
            }// Encerra o if()
            // Selecionado o identificador(key) de cada registro e associando 
            _registro[registroReserva.Id] = registroReserva;

            return registroReserva;
        }
        // 9 passo: definir a implementação do método de atualização

        public Reserva UpdateReserva(Reserva registroAtualizado) => AddReserva(registroAtualizado);

        // 10 passo: definir o método de exclusão de registro

        public void DeleteReserva(int id) => _registro.Remove(id);

    }
}
