using Microsoft.EntityFrameworkCore;
using Tarefas.Data;
using Tarefas.Domain.Entities;
using Tarefas.Repository.Interface;

namespace Products.Repository
{
    public class ProductRepository : ITarefaRepository
    {
        protected readonly TarefaContext _context;
        protected readonly DbSet<Tarefa> _tarefa;

        public ProductRepository(TarefaContext context)
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
        public Tarefa Update(Tarefa product)
        {
            _tarefa.Update(product);
            _context.SaveChanges();
            return product;
        }
        public bool Delete(int id)
        {
            var product = _tarefa.Find(id);
            if (product == null) return false;
            _tarefa.Remove(product);
            _context.SaveChanges();
            return true;
        }
    }
}
