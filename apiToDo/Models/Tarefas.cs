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


        public void InserirTarefa(DSTarefaDTO tarefa)
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

        public TarefaDTO BuscarTarefaId(int idTarefa)
        {
            var tarefa= _lstTarefas.FirstOrDefault(x => x.ID_TAREFA == idTarefa);
            if (tarefa == null)
                throw new ErrorResponse(StatusCodes.Status404NotFound, "Tarefa não encontrada");
            return tarefa;
        }

        public TarefaDTO AtualizarTarefa(int idTarefa, DSTarefaDTO description)
        {
            var tarefa = BuscarTarefaId(idTarefa);
            tarefa.DS_TAREFA = description.Descricao;
            return tarefa;
        }

        // metodo de buscar tarefa pela a DS, a DS ignorando o case
        public TarefaDTO BuscarTarefaDS(string ds)
        {
            var tarefa = _lstTarefas.FirstOrDefault(x => x.DS_TAREFA.ToLower()== ds.ToLower());
            if (tarefa==null)
                throw new ErrorResponse(StatusCodes.Status404NotFound, "Tarefa Não encontrada");
            return tarefa;
        }

        public TarefaDTO AtualizarTarefaDS(string ds, DSTarefaDTO dsTarefa)
        {
            var tarefa = BuscarTarefaDS(ds);
            tarefa.DS_TAREFA = dsTarefa.Descricao;
            return tarefa;

        }
    }
}
