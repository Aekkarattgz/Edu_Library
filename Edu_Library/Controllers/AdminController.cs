using Edu_Library.Data;
using Microsoft.AspNetCore.Mvc;
using Edu_Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;  // เพิ่มบรรทัดนี้

public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Action Method สำหรับหน้า Admin
    public IActionResult Admin()
    {
        IEnumerable<Book_tb> books = _context.Book_tb
                .Include(b => b.Category)
                .ToList();

        return View(books);
    }

    // GET: Admin/Create
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(_context.Category_tb, "CategoryId", "Name");
        return View();
    }

    // POST: Admin/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Book_tb book)
    {
        if (ModelState.IsValid)
        {
            _context.Add(book);
            _context.SaveChanges();
            return RedirectToAction(nameof(Admin));
        }

        ViewBag.Categories = new SelectList(_context.Category_tb, "CategoryId", "Name", book.CategoryId);
        return View(book);
    }

    // GET: Admin/Edit/5
    public IActionResult Edit(int id)
    {
        var book = _context.Book_tb.Find(id);
        if (book == null)
        {
            return NotFound();
        }

        ViewBag.Categories = new SelectList(_context.Category_tb, "CategoryId", "Name", book.CategoryId);
        return View(book);
    }

    // POST: Admin/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Book_tb book)
    {
        if (id != book.BookId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(book);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Book_tb.Any(e => e.BookId == book.BookId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Admin));
        }

        ViewBag.Categories = new SelectList(_context.Category_tb, "CategoryId", "Name", book.CategoryId);
        return View(book);
    }

    // GET: Admin/Delete/5
    public IActionResult Delete(int id)
    {
        var book = _context.Book_tb.Find(id);
        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }

    // POST: Admin/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var book = _context.Book_tb.Find(id);
        _context.Book_tb.Remove(book);
        _context.SaveChanges();
        return RedirectToAction(nameof(Admin));
    }
}
