using Microsoft.EntityFrameworkCore;
using Tarefas.Domain.Entities;

namespace Tarefas.Data
{
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> opt) : base(opt)
        {
        }

        public virtual DbSet<Tarefa> Tarefa { get; set; }

    }
}