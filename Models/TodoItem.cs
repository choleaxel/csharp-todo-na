using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Models;

public class TodoItem
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Title { get; set; }

    public bool isCompleted { get; set; }
}