namespace BookStoreApi.Models;

public class BookStoreDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string BooksCollectionName { get; set; } = null!;
    
    public string AuthorsCollectionName { get; set; } = null!;
    
    public string GenresCollectionName { get; set; } = null!;
    
    public string ReviewsCollectionName { get; set; } = null!;
    
    public string UsersCollectionName { get; set; } = null!;
}