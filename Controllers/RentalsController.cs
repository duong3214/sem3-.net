using Microsoft.AspNetCore.Mvc;               // Để sử dụng Controller, IActionResult, View, RedirectToAction...
using Microsoft.EntityFrameworkCore;           // Để sử dụng các phương thức như Where, Include, ToListAsync...
using ComicSystem.Models;                     // Để sử dụng các model như Rental, ComicSystemDbContext
using System.Linq;                            // Để sử dụng phương thức LINQ như Where
using System.Threading.Tasks;                 // Để sử dụng Task trong phương thức bất đồng bộ (async)
using System;                                 // Để sử dụng các kiểu dữ liệu như DateTime

public class RentalsController : Controller
{
    private readonly ComicSystemDbContext _context;

    public RentalsController(ComicSystemDbContext context)
    {
        _context = context;
    }

    public IActionResult Report() => View();

    [HttpPost]
    public async Task<IActionResult> Report(DateTime startDate, DateTime endDate)
    {
        var rentals = await _context.Rentals
            .Where(r => r.RentalDate >= startDate && r.RentalDate <= endDate)
            .Include(r => r.Customer)
            .Include(r => r.RentalDetails)
            .ToListAsync();

        return View(rentals);
    }
}
