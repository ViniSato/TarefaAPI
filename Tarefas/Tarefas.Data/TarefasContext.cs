using Microsoft.EntityFrameworkCore;
using Tarefas.Domain.Entities;

namespace Tarefas.Data
{
    public class TarefasContext : DbContext
    {
        public TarefasContext(DbContextOptions<TarefasContext> opt) : base(opt)
        {
        }

        public virtual DbSet<Tarefa> Tarefa { get; set; }

    }
}