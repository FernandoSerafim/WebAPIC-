using SistemaDeTarefas.Enuns;

namespace SistemaDeTarefas.Models
{
    //Utilizada para cadastro de tarefas dentro do meu sistema
    public class TarefaModel
    {
        public int IdTarefa { get; set; }
        public string? NmTarefa { get; set;}
        public string? DsTarefa { get; set;}
        public StatusTarefa StatusTarefa { get; set;} //Tarefa pendente, iniciada ou finalizada

    }
}
