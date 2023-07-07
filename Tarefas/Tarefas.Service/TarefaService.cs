using Tarefas.Domain.Entities;
using Tarefas.Domain.ViewModel;
using Tarefas.Repository.Interface;
using Tarefas.Service.Interface;

namespace Tarefas.Service
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _repository;
        public TarefaService(ITarefaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Tarefa>> GetTarefas()
        {
            var tarefaList = await _repository.GetTarefas();
            return tarefaList.OrderBy(v => v.Id);
        }
        public async Task<Tarefa> GetById(int id)
        {
            var tarefa = await _repository.GetById(id);
            if (tarefa == null) throw new Exception("Tarefa não existe");
            return tarefa;
        }
        public Tarefa Add(TarefaViewModel tarefa)
        {
            var newTarefa = new Tarefa(tarefa.Titulo, tarefa.Descricao, tarefa.Concluida, tarefa.Data);
            return _repository.Add(newTarefa);
        }
        public Tarefa Update(int id, TarefaViewModel tarefa)
        {
            var newTarefa = new Tarefa(id, tarefa.Titulo, tarefa.Descricao, tarefa.Concluida, tarefa.Data);
            return _repository.Update(newTarefa);
        }
        public bool Delete(int id) => _repository.Delete(id);
    }
}
