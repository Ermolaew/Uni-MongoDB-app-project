using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookStoreApi.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    [JsonPropertyName("Name")]
    public string Name { get; set; } = null!;
    
    public string Login { get; set; } = null!;
    
    public string Password { get; set; } = null!;
    
    public string[] Favorites { get; set; } = null!;
    
    public string[] Reviews { get; set; } = null!;
}