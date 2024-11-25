using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookStoreApi.Models;

public class Author
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    [JsonPropertyName("Name")]
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string WikiLink { get; set; } = null!;

    public string[] Books { get; set; } = null!;
}