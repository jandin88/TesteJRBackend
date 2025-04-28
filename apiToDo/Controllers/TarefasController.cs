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

        //[Authorize]
        [HttpGet("lstTarefas")]
        public ActionResult<List<TarefaDTO>>lstTarefas()
        {
            //chama a funcao findTarefas do obj Tarefas
            var tarefas = tarefasService.findTarefas();
            //retorna a lista de tarefas
            return Ok(tarefas);
        }

        [HttpPost("InserirTarefas")]
        public ActionResult<List<TarefaDTO>>InserirTarefas([FromBody] CriarTarefaDTO description)
        {
            //chama a funcao InserirTarefa do obj Tarefas
            tarefasService.InserirTarefa(description);
            //retorna a lista de tarefas
            var lisTarefas = tarefasService.findTarefas();
            return Ok(lisTarefas);
        }

        [HttpDelete("DeletarTarefa")]
        public ActionResult DeletarTarefa([FromQuery] int ID_TAREFA)
        {
            //chama a funcao DeletarTarefa do obj Tarefas
            tarefasService.DeletarTarefa(ID_TAREFA);
            //retorna a lista de tarefas
            var lisTarefas = tarefasService.findTarefas();
            return Ok(lisTarefas);        }
    }
}

