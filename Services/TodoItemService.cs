using Models;
using Settings;
namespace Services;


public interface ITodoItemService
{
    Task<IEnumerable<TodoItemService>> GetAllTodoItems();
    Task<TodoItem> GetTodoItemById(string id);
    Task<TodoItem> UpdateTodoItem(string id, TodoItem todoItem);

    Task<TodoItem> CreateTodoItem(TodoItem todoItem);
}
public class TodoItemService : ITodoItemService

{
    private readonly IMongoCollection<TodoItem> todoItemCollection;
    public TodoItemService(IOptions<TodoDbSettings> todoDbSettings);
    {
        var client = new MongoClient(todoDbSettings.Value.ConnectionString);
        var db = client.GetDatabase(TodoDbSettings.Value.DatabaseName);
        todoItemCollection = db.GetCollection<TodoItem>(todoDbSettings.Value.DatabaseName);
    }
    public async Task<TodoItem> CreateTodoItem(TodoItem newTodoItem)
    {
        await todoItemCollection.InsertOneAsync(newTodoItem);
        return newTodoItem;
        
    }

    public async Task<IEnumerable<TodoItem>> GetAllTodoItems()

    {
        var res = await todoItemCollection.FindAsync( x =>)
        throw new NotImplementedException();
    }

    public Task<TodoItem> GetTodoItemById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<TodoItem> UpdateTodoItem(string id, TodoItem todoItem)
    {
        throw new NotImplementedException();
    }
}