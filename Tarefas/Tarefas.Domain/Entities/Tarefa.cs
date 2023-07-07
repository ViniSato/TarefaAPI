using System.ComponentModel.DataAnnotations;

namespace Tarefas.Domain.Entities
{
    public class Tarefa
    {
        public Tarefa(string titulo, string descricao, bool concluida, DateTime data) => (Id, Titulo, Descricao, Concluida, Data) = (0, titulo, descricao, concluida, data);
        public Tarefa(int id, string titulo, string descricao, bool concluida, DateTime data) => (Id, Titulo, Descricao, Concluida, Data) = (id, titulo, descricao, concluida, data);

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool Concluida { get; set; }
        public DateTime Data { get; set; }
    }
}
