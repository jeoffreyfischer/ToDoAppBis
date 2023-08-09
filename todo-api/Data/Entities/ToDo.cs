namespace todo_api.Data.Entities;

public class ToDo
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsComplete { get; set; }
}