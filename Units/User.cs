public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public int[] Favorites { get; set; } // массив айдишников книг
    public int[] Reviews { get; set; }
}