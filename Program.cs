using Services;
using Settings;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<TodoDbSettings>(builder.Configuration.GetSection("TodoDB"));
builder.Services.AddSingleton<ITodoItemService, TodoItemService>();
var app = builder.Build();

app.MapGet("/todo-items", async (ITodoItemService todoItemService) => {
    var todos = await todoItemService.GetAllTodoItems();
    return Results.Ok(todos);
});

app.MapGet("/todo-items/{id}", async (string id, ITodoItemService todoItemService) => {
    var todoItem = await todoItemService.GetTodoItemById(id);
    return Results.Ok(todoItem);
});

app.MapPost("/todo-items", () => {});
app.MapPut("/todo-items/{id}", (string id) => {}); //to update need id
app.MapDelete("/todo-items/{id}", (string id) => {}); //to delete need id

app.Run();


