using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookStoreApi.Models;

public class Book
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    [JsonPropertyName("Name")]
    public string BookName { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Year { get; set; } = null!;
}