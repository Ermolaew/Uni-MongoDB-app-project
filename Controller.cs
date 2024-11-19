using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MongoDbContext>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "API";
    config.Title = "API";
    config.Version = "v1";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "API";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}


//Users

app.MapGet("/GetUsers", async (MongoDbContext db) =>
    await db.Users.ToListAsync());

app.MapGet("/GetUsers/{id}", async (int id, MongoDbContext db) =>
    await db.Users.FindAsync(id)
        is User userUnit
            ? Results.Ok(userUnit)
            : Results.NotFound());

app.MapPost("/PostUsers", async (User userUnit, MongoDbContext db) =>
{
    db.Users.Add(userUnit);
    await db.SaveChangesAsync();

    return Results.Created($"/PostUsers/{userUnit.Id}", userUnit);
});

app.MapPut("/PutUsers/{id}", async (int id, User user, MongoDbContext db) =>
{
    var userUnit = await db.Users.FindAsync(id);

    if (userUnit is null) return Results.NotFound();

    userUnit.Name = user.Name;
    userUnit.Login = user.Login;
    userUnit.Password = user.Password;
    userUnit.Favorites = user.Favorites;
    userUnit.Reviews = user.Reviews;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/DeleteUsers/{id}", async (int id, MongoDbContext db) =>
{
    if (await db.Users.FindAsync(id) is User userUnit)
    {
        db.Users.Remove(userUnit);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

//Books

app.MapGet("/GetBooks", async (MongoDbContext db) =>
    await db.Books.ToListAsync());

app.MapGet("/GetBooks/{id}", async (int id, MongoDbContext db) =>
    await db.Books.FindAsync(id)
        is Book bookUnit
            ? Results.Ok(bookUnit)
            : Results.NotFound());

app.MapPost("/PostBooks", async (Book bookUnit, MongoDbContext db) =>
{
    db.Books.Add(bookUnit);
    await db.SaveChangesAsync();

    return Results.Created($"/PostBooks/{bookUnit.Id}", bookUnit);
});

app.MapPut("/PutBooks/{id}", async (int id, Book book, MongoDbContext db) =>
{
    var bookUnit = await db.Books.FindAsync(id);

    if (bookUnit is null) return Results.NotFound();

    bookUnit.Name = book.Name;
    bookUnit.Author = book.Author;
    bookUnit.Genre = book.Genre;
    bookUnit.Description = book.Description;
    bookUnit.Year = book.Year;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/DeleteBooks/{id}", async (int id, MongoDbContext db) =>
{
    if (await db.Books.FindAsync(id) is Book bookUnit)
    {
        db.Books.Remove(bookUnit);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

//Reviews

app.MapGet("/GetReviews", async (MongoDbContext db) =>
    await db.Reviews.ToListAsync());

app.MapGet("/GetReviews/{id}", async (int id, MongoDbContext db) =>
    await db.Reviews.FindAsync(id)
        is Review reviewUnit
            ? Results.Ok(reviewUnit)
            : Results.NotFound());

app.MapPost("/PostReviews", async (Review reviewUnit, MongoDbContext db) =>
{
    db.Reviews.Add(reviewUnit);
    await db.SaveChangesAsync();

    return Results.Created($"/PostReviews/{reviewUnit.Id}", reviewUnit);
});

app.MapPut("/PutReviews/{id}", async (int id, Review review, MongoDbContext db) =>
{
    var reviewUnit = await db.Reviews.FindAsync(id);

    if (reviewUnit is null) return Results.NotFound();

    reviewUnit.Content = review.Content;
    reviewUnit.BookId = review.BookId;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/DeleteReviews/{id}", async (int id, MongoDbContext db) =>
{
    if (await db.Reviews.FindAsync(id) is Review reviewUnit)
    {
        db.Reviews.Remove(reviewUnit);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

//Authors

app.MapGet("/GetAuthors", async (MongoDbContext db) =>
    await db.Authors.ToListAsync());

app.MapGet("/GetAuthors/{id}", async (int id, MongoDbContext db) =>
    await db.Authors.FindAsync(id)
        is Author authorUnit
            ? Results.Ok(authorUnit)
            : Results.NotFound());

app.MapPost("/PostAuthors", async (Author authorUnit, MongoDbContext db) =>
{
    db.Authors.Add(authorUnit);
    await db.SaveChangesAsync();

    return Results.Created($"/PostAuthors/{authorUnit.Id}", authorUnit);
});

app.MapPut("/PutAuthors/{id}", async (int id, Author author, MongoDbContext db) =>
{
    var authorUnit = await db.Authors.FindAsync(id);

    if (authorUnit is null) return Results.NotFound();

    authorUnit.Name = author.Name;
    authorUnit.Description = author.Description;
    authorUnit.WikiLink = author.WikiLink;
    authorUnit.Books = author.Books;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/DeleteAuthors/{id}", async (int id, MongoDbContext db) =>
{
    if (await db.Authors.FindAsync(id) is Author authorUnit)
    {
        db.Authors.Remove(authorUnit);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

//Genres

app.MapGet("/GetGenres", async (MongoDbContext db) =>
    await db.Genres.ToListAsync());

app.MapGet("/GetGenres/{id}", async (int id, MongoDbContext db) =>
    await db.Genres.FindAsync(id)
        is Genre genreUnit
            ? Results.Ok(genreUnit)
            : Results.NotFound());

app.MapPost("/PostGenres", async (Genre genreUnit, MongoDbContext db) =>
{
    db.Genres.Add(genreUnit);
    await db.SaveChangesAsync();

    return Results.Created($"/PostGenres/{genreUnit.Id}", genreUnit);
});

app.MapPut("/PutGenres/{id}", async (int id, Genre genre, MongoDbContext db) =>
{
    var genreUnit = await db.Genres.FindAsync(id);

    if (genreUnit is null) return Results.NotFound();

    genreUnit.Name = genre.Name;
    genreUnit.Authors = genre.Authors;
    genreUnit.Books = genre.Books;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/DeleteGenres/{id}", async (int id, MongoDbContext db) =>
{
    if (await db.Genres.FindAsync(id) is Genre genreUnit)
    {
        db.Genres.Remove(genreUnit);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.Run();