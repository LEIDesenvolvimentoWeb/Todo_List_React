namespace ToDoList.DTO
{
    public class ToDoDTO
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataParaConcluir { get; set; }
        public DateTime? DataConclusao { get; set; }
        public int Tipo { get; set; }
    }
}