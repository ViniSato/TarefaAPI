using Tarefas.Domain.Entities;
using Tarefas.Domain.Exceptions;
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
            var product = await _repository.GetById(id);
            if (product == null) throw new TarefaException("Tarefa não existe");
            return product;
        }
        public Tarefa Add(TarefaViewModel tarefa)
        {
            var newProduct = new Tarefa(tarefa.Titulo, tarefa.Descricao, tarefa.Concluida, tarefa.Data);
            return _repository.Add(newProduct);
        }
        public Tarefa Update(int id, TarefaViewModel tarefa)
        {
            var newProduct = new Tarefa(id, tarefa.Titulo, tarefa.Descricao, tarefa.Concluida, tarefa.Data);
            return _repository.Update(newProduct);
        }
        public bool Delete(int id) => _repository.Delete(id);
    }
}
