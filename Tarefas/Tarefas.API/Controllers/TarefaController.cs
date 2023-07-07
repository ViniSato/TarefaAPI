﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<Tarefa>> GetProductById([FromRoute] int id) => Ok(await _tarefa.GetById(id));

        [HttpPost]
        public ActionResult<Tarefa> AddProducts([FromBody] TarefaViewModel tarefa) => Created("", _tarefa.Add(tarefa));

        [HttpPut("{id:int}")]
        public ActionResult<Tarefa> UpdateProduct([FromRoute] int id, [FromBody] TarefaViewModel tarefa) => Created("", _tarefa.Update(id, tarefa));

        [HttpDelete("{id:int}")]
        public ActionResult<bool> DeleteProductById([FromRoute] int id) => Ok(_tarefa.Delete(id));
    }
}
