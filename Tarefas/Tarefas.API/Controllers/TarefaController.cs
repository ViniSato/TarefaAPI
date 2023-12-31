﻿using Microsoft.AspNetCore.Mvc;
using Tarefas.Domain.Entities;
using Tarefas.Domain.ViewModel;
using Tarefas.Service.Interface;

namespace Tarefas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefa;
        public TarefaController(ITarefaService tarefa)
        {
            _tarefa = tarefa;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefas() => Ok(await _tarefa.GetTarefas());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Tarefa>> GetTarefaById([FromRoute] int id)
        {
            try
            {
                var resposta = await _tarefa.GetById(id);
                return resposta;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Tarefa> AddTarefa([FromBody] TarefaViewModel tarefa) => Created("", _tarefa.Add(tarefa));

        [HttpPut("{id:int}")]
        public ActionResult<Tarefa> UpdateTarefa([FromRoute] int id, [FromBody] TarefaViewModel tarefa)
        {
            try
            {
                var resposta = Created("", _tarefa.Update(id, tarefa));
                return resposta;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<bool> DeleteTarefaById([FromRoute] int id)
        {
            try
            {
                var resposta = Ok(_tarefa.Delete(id));
                return resposta;    
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
