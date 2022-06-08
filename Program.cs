using Services;
using Settings;
using Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<TodoDbSettings>(builder.Configuration.GetSection("TodoDB"));
builder.Services.AddSingleton<ITodoItemService, TodoItemService>();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/todo-items", async (ITodoItemService todoItemService) => {
    var todos = await todoItemService.GetAllTodoItems();
    return Results.Ok(todos);
});

app.MapGet("/todo-items/{id}", async (string id, ITodoItemService todoItemService) => {
    var todoItem = await todoItemService.GetTodoItemById(id);
    return Results.Ok(todoItem);
});

app.MapPost("/todo-items", async (TodoItem newVoodo, ITodoItemService service) => {
    TodoItem createdTodoItem = await service.CreateTodoItem(newVoodo);
    return Results.CreatedAtRoute($"todo-items/{createdTodoItem.Id}"); //if you follow this link you will get
    //to this new item
});
app.MapPut("/todo-items/{id}", (string id) => {}); //to update need id
app.MapDelete("/todo-items/{id}", (string id) => {}); //to delete need id

app.Run();


