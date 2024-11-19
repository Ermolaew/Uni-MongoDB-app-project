using Microsoft.EntityFrameworkCore;

class MongoDbContext : DbContext
{
    public MongoDbContext(DbContextOptions<MongoDbContext> options)
        : base(options) { }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Genre> Genres => Set<Genre>();
}