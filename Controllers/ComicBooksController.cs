using Microsoft.AspNetCore.Mvc;               // Để sử dụng Controller, IActionResult, View, RedirectToAction...
using Microsoft.EntityFrameworkCore;           // Để sử dụng các phương thức như ToListAsync, SaveChangesAsync...
using ComicSystem.Models;                     // Để sử dụng các model như ComicBook, ComicSystemDbContext
using System.Threading.Tasks;                 // Để sử dụng Task trong phương thức bất đồng bộ (async)

public class ComicBooksController : Controller
{
    private readonly ComicSystemDbContext _context;

    public ComicBooksController(ComicSystemDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.ComicBooks.ToListAsync());
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(ComicBook comicBook)
    {
        if (ModelState.IsValid)
        {
            _context.Add(comicBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(comicBook);
    }

    // Edit, Delete, Details methods omitted for brevity
}
