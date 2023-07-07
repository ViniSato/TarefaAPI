using Tarefas.Domain.Entities;

namespace Tarefas.Repository.Interface
{
    public interface ITarefaRepository
    {
        Tarefa Add(Tarefa tarefa);
        Task<IEnumerable<Tarefa>> GetTarefas();
        Task<Tarefa> GetById(int id);
        Tarefa Update(Tarefa tarefa);
        bool Delete(int id);
    }
}