using System.ComponentModel.DataAnnotations;

namespace Tarefas.Domain.ViewModel
{
    public class TarefaViewModel
    {
        [StringLength(100)]
        [Required]
        public string Titulo { get; set; }
        [StringLength(100)]
        [Required]
        public string Descricao { get; set; }
        public bool Concluida { get; set; }
        public DateTime Data { get; set; }
    }
}
