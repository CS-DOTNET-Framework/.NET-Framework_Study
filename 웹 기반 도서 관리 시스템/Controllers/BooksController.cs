using System.Linq;
using System.Web.Mvc;

public class BooksController : Controller
{
    private readonly LibraryContext db = new LibraryContext();

    public ActionResult Index()
    {
        var books = db.Books.ToList();
        return View(books);
    }

    public ActionResult Details(int id)
    {
        var book = db.Books.Find(id);
        if (book == null) return HttpNotFound();
        return View(book);
    }

    [Authorize(Roles = "Admin")]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public ActionResult Create(Book book)
    {
        if (ModelState.IsValid)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(book);
    }

    [Authorize(Roles = "Admin")]
    public ActionResult Edit(int id)
    {
        var book = db.Books.Find(id);
        if (book == null) return HttpNotFound();
        return View(book);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public ActionResult Edit(Book book)
    {
        if (ModelState.IsValid)
        {
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(book);
    }

    [Authorize(Roles = "Admin")]
    public ActionResult Delete(int id)
    {
        var book = db.Books.Find(id);
        if (book == null) return HttpNotFound();
        return View(book);
    }

    [HttpPost, ActionName("Delete")]
    [Authorize(Roles = "Admin")]
    public ActionResult DeleteConfirmed(int id)
    {
        var book = db.Books.Find(id);
        db.Books.Remove(book);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
}
