using System.Data.Entity;

public class LibraryContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<LoanRecord> LoanRecords { get; set; }

    public LibraryContext() : base("LibraryDB") { }
}
