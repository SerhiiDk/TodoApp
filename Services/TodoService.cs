using TodoApp.Models;

namespace TodoApp.Services;

public class TodoService
{
    private readonly List<TodoItem> _items = [];
    private int _nextId = 1;

    public IReadOnlyList<TodoItem> GetAll() => _items.AsReadOnly();

    public void Add(string title)
    {
        if (string.IsNullOrWhiteSpace(title)) return;
        _items.Add(new TodoItem { Id = _nextId++, Title = title.Trim() });
    }

    public void Toggle(int id)
    {
        var item = _items.FirstOrDefault(x => x.Id == id);
        if (item is not null) item.IsCompleted = !item.IsCompleted;
    }

    public void Delete(int id) => _items.RemoveAll(x => x.Id == id);
}
