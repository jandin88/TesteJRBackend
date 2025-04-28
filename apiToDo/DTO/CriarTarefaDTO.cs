using System;

namespace apiToDo.DTO
{

    //criei essa classe para receber o parametro de descrição da tarefa para o usuario não precisar digitar.
    public class CriarTarefaDTO
    {
        public String Descricao { get; set; }
    }
}