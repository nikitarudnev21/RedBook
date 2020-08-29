using SQLite;

namespace RedBook2
{
    [Table("BookAdmin")]
    public class BookAdmin
    {
        public string Login { get; set; } = "Book1";
        public string Password { get; set; } = "red2";
    }
}