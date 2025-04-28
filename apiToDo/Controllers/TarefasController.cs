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
            var tarefas = tarefasService.findTarefas();
            return Ok(tarefas);
        }

        [HttpPost("InserirTarefas")]
        public ActionResult InserirTarefas([FromBody] CriarTarefaDTO description)
        {
            String idTarefa = tarefasService.InserirTarefa(description);
            return StatusCode(201, new { Id = idTarefa, menssage = "inserida com sucesso" });

        }

        [HttpDelete("DeletarTarefa")]
        public ActionResult DeletarTarefa([FromQuery] int ID_TAREFA)
        {
           tarefasService.DeletarTarefa(ID_TAREFA);
            return StatusCode(200, new { Id = ID_TAREFA, menssage = "Deletada com sucesso" });
        }

    }
}

