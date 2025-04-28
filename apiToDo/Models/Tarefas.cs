using apiToDo.DTO;
using System.Collections.Generic;
using System.Linq;
using apiToDo.Exception;
using Microsoft.AspNetCore.Http;

namespace apiToDo.Models
{
    public class Tarefas {

        private static readonly List<TarefaDTO> _lstTarefas = new List<TarefaDTO>
        {
            new() { ID_TAREFA = 1, DS_TAREFA = "Fazer Compras" },
            new() { ID_TAREFA = 2, DS_TAREFA = "Fazer Atividade da Faculdade" },
            new() { ID_TAREFA = 3, DS_TAREFA = "Subir Projeto de Teste no GitHub" }
        };

        public List<TarefaDTO> findTarefas() {

            //verificando se a lista e nula
            if (_lstTarefas.Count == 0) {
                throw new ErrorResponse(StatusCodes.Status404NotFound,"Lista de tarefas vazia");
            }
            //retornando a lista
            return _lstTarefas;
        }


        public void InserirTarefa(CriarTarefaDTO tarefa)
        {
            //validando
            if (string.IsNullOrWhiteSpace(tarefa.Descricao))
                throw new ErrorResponse(StatusCodes.Status400BadRequest,"Adicione uma descrição válida para a tarefa");

            var tarefaDuplicada=_lstTarefas.Any(x=>x.DS_TAREFA==tarefa.Descricao);
            if(tarefaDuplicada)
                throw new ErrorResponse(StatusCodes.Status400BadRequest,"tarefa já adicionada");

            //criando o id incremental
            var idIncremental = _lstTarefas.Any() ? _lstTarefas.Last().ID_TAREFA + 1 : 1;

            //adicionando na lista
            _lstTarefas.Add(new(idIncremental, tarefa.Descricao));

        }
        public void DeletarTarefa(int ID_TAREFA)
        {
            //validando se o id existe
            var tarefaId= _lstTarefas.RemoveAll(x => x.ID_TAREFA == ID_TAREFA);
            // se não existir retornar erro
            if (tarefaId==0)
                throw new ErrorResponse(StatusCodes.Status404NotFound,"ID não encontrado");
        }
    }
}
