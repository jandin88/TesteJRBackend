using apiToDo.DTO;
using apiToDo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace apiToDo.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {

        // criando um obj de Tarefas
        private readonly Tarefas tarefasService;

        //fazendo injeção de dependencia
        public TarefasController(Tarefas tarefasService)
        {
            this.tarefasService = tarefasService;
        }

        [HttpGet("lstTarefas")]
        public ActionResult<List<TarefaDTO>>lstTarefas()
        {
            //chama a funcao findTarefas do obj Tarefas
            var tarefas = tarefasService.findTarefas();
            //retorna a lista de tarefas
            return Ok(tarefas);
        }

        //buscar tarefas por id
        [HttpGet("tarefas/{ID}")]
        public ActionResult<TarefaDTO> BuscarTarefaPorId(int ID)
        {
            //chama a funcao buscarTarefaID do obj Tarefas
            var tarefa = tarefasService.BuscarTarefaId(ID);
            //retorna a lista de tarefas
            return Ok(tarefa);
        }


        [HttpGet("tarefas/ds/{DS}")]
        public ActionResult<TarefaDTO> BuscarTarefaPelaDS(String DS)
        {
            //chama a funcao buscarTarefaID do obj Tarefas
            var tarefa = tarefasService.BuscarTarefaDS(DS);
            //retorna a lista de tarefas
            return Ok(tarefa);
        }


        [HttpPost("tarefas")]
        public ActionResult<List<TarefaDTO>>InserirTarefas([FromBody] DSTarefaDTO dsTarefa)
        {
            //chama a funcao InserirTarefa do obj Tarefas
            tarefasService.InserirTarefa(dsTarefa);
            //retorna a lista de tarefas
            var lisTarefas = tarefasService.findTarefas();
            return Ok(lisTarefas);
        }


        [HttpPut("tarefas/{id}")]
        public ActionResult<TarefaDTO> atualizarTarefa(int id, [FromBody] DSTarefaDTO dsTarefa)
        {
            var tarefaAtualizada = tarefasService.AtualizarTarefa(id, dsTarefa);
            return Ok(tarefaAtualizada);
        }

        [HttpPut("tarefas/DS/{DS}")]
        public ActionResult<TarefaDTO> atualizarTarefaDS(String DS, [FromBody] DSTarefaDTO dsTarefa)
        {
            var tarefaAtualizada = tarefasService.AtualizarTarefaDS(DS, dsTarefa);
            return Ok(tarefaAtualizada);
        }

        [HttpDelete("tarefas")]
        public ActionResult DeletarTarefa([FromQuery] int ID)
        {
            //chama a funcao DeletarTarefa do obj Tarefas
            tarefasService.DeletarTarefa(ID);
            //retorna a lista de tarefas
            var lisTarefas = tarefasService.findTarefas();
            return Ok(lisTarefas);        }
    }
}

