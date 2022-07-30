// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using UdemyEFCore.DatabaseFirst.DAL;

DbContenxtInitializer.Build();

using (var _context = new AppDbContext())
{

    var products = await _context.Products.ToListAsync();
    products.ForEach(p =>
    {
        Console.WriteLine("Id: {0}, Name: {1}", p.Id, p.Name);
    });
}
