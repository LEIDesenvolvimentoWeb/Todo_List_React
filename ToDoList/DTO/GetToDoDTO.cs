namespace ToDoList.DTO
{
    public class GetToDoDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string DataCriacao { get; set; }
        public string DataParaConcluir { get; set; }
        public string DataConclusao { get; set; }
        public string Tipo { get; set; }
        public string Ficheiro { get; set; }
        public string Directoria { get; set; }
    }
}