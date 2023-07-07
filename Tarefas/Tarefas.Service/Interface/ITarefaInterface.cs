using Tarefas.Domain.Entities;
using Tarefas.Domain.ViewModel;

namespace Tarefas.Service.Interface
{
    public interface ITarefaService
    { 
        Tarefa Add(TarefaViewModel tarefa);
        Task<IEnumerable<Tarefa>> GetTarefas();
        Task<Tarefa> GetById(int id);
        Tarefa Update(int id, TarefaViewModel tarefa);
        bool Delete(int id);
    }
}