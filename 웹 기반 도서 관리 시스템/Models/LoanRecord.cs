public class LoanRecord
{
    public int LoanId { get; set; }
    public int BookId { get; set; }
    public virtual Book Book { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}
