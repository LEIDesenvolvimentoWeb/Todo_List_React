using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataParaConcluir { get; set; }
        public DateTime? DataConclusao { get; set; }

        // Fk
        [ForeignKey(nameof(Tipo))]
        public int TipoId { get; set; }

        public ToDoType Tipo { get; set; }
        public string Ficheiro { get; set; }
    }
}