namespace ToDoList.Models
{
    public class ToDoType
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<ToDo> ToDoLista { get; set; }
    }
}