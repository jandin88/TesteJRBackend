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
            try
            {
                var tarefas = tarefasService.findTarefas();
                return Ok(tarefas);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpPost("InserirTarefas")]
        public ActionResult InserirTarefas([FromBody] CriarTarefaDTO description)
        {
            try
            {
                String idTarefa = tarefasService.InserirTarefa(description);


                return StatusCode(201, new { Id = idTarefa, menssage = "inserida com sucesso" });

            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpGet("DeletarTarefa")]
        public ActionResult DeleteTask([FromQuery] int ID_TAREFA)
        {
            try
            {

                return StatusCode(200);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

    }
}

