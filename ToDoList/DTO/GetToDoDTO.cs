namespace ToDoList.DTO
{
    public class GetToDoDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataParaConcluir { get; set; }
        public DateTime? DataConclusao { get; set; }
        public string Tipo { get; set; }
        public string Ficheiro { get; set; }
    }
}