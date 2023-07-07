using Microsoft.EntityFrameworkCore;
using Tarefas.Data;
using Tarefas.Domain.Entities;
using Tarefas.Repository.Interface;

namespace Tarefas.Repository
{
    public class TarefaRepository : ITarefaRepository
    {
        protected readonly TarefasContext _context;
        protected readonly DbSet<Tarefa> _tarefa;

        public TarefaRepository(TarefasContext context)
        {
            _context = context;
            _tarefa = context.Set<Tarefa>();
        }

        public async Task<IEnumerable<Tarefa>> GetTarefas() => await _tarefa.ToListAsync();
        public async Task<Tarefa> GetById(int id) => await _tarefa.FindAsync(id);
        public Tarefa Add(Tarefa tarefa)
        {
            _tarefa.Add(tarefa);
            _context.SaveChanges();
            return tarefa;
        }
        public Tarefa Update(Tarefa tarefa)
        {
            _tarefa.Update(tarefa);
            _context.SaveChanges();
            return tarefa;
        }
        public bool Delete(int id)
        {
            var tarefa = _tarefa.Find(id);
            if (tarefa == null) return false;
            _tarefa.Remove(tarefa);
            _context.SaveChanges();
            return true;
        }
    }
}
