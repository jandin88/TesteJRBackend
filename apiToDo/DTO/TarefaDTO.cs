using System;

namespace apiToDo.DTO
{
    public class TarefaDTO
    {
        public int ID_TAREFA { get; set; }
        public string DS_TAREFA { get; set; }

        public TarefaDTO(int idTarefa, string dsTarefa)
        {
            ID_TAREFA = idTarefa;
            DS_TAREFA = dsTarefa;
        }

        public TarefaDTO(){ }
    }
}
