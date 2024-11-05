public class LoanController : Controller
{
    private readonly LibraryContext db = new LibraryContext();

    public ActionResult Index()
    {
        var loans = db.LoanRecords.Include("Book").Include("User").ToList();
        return View(loans);
    }

    public ActionResult LoanBook(int bookId, int userId)
    {
        var book = db.Books.Find(bookId);
        if (book == null || !book.IsAvailable) return HttpNotFound();

        var loan = new LoanRecord
        {
            BookId = bookId,
            UserId = userId,
            LoanDate = DateTime.Now
        };

        book.IsAvailable = false;
        db.LoanRecords.Add(loan);
        db.SaveChanges();

        return RedirectToAction("Index");
    }

    public ActionResult ReturnBook(int loanId)
    {
        var loan = db.LoanRecords.Find(loanId);
        if (loan == null) return HttpNotFound();

        loan.ReturnDate = DateTime.Now;
        loan.Book.IsAvailable = true;
        db.SaveChanges();

        return RedirectToAction("Index");
    }
}
