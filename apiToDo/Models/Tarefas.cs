using apiToDo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace apiToDo.Models
{
    public class Tarefas {

        private static List<TarefaDTO> _lstTarefas = new List<TarefaDTO>
        {
            new() { ID_TAREFA = 1, DS_TAREFA = "Fazer Compras" },
            new() { ID_TAREFA = 2, DS_TAREFA = "Fazer Atividade da Faculdade" },
            new() { ID_TAREFA = 3, DS_TAREFA = "Subir Projeto de Teste no GitHub" }
        };

        public List<TarefaDTO> findTarefas()
        {
            return _lstTarefas;
        }


        public String InserirTarefa(CriarTarefaDTO tarefa)
        {
            if (tarefa == null)
            {
                throw new ArgumentException("Adicione uma descrição válida para a tarefa");
            }

            int ID_TAREFA = _lstTarefas.Count + 1;
            _lstTarefas.Add(new(ID_TAREFA, tarefa.descricao));

            return ID_TAREFA.ToString();

        }
        public void DeletarTarefa(int ID_TAREFA)
        {
            try
            {
                // List<TarefaDTO> lstResponse = lstTarefas();
                // var Tarefa = lstResponse.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);
                // TarefaDTO Tarefa2 = lstResponse.Where(x=> x.ID_TAREFA == Tarefa.ID_TAREFA).FirstOrDefault();
                // lstResponse.Remove(Tarefa2);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
