// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Console.WriteLine("Hello, World!");

// Unchanged : ilk cekilen dataya state olarak atar. data database ile ayni. 

using (var context = new AppDbContext())
{
    var newProduct = new Product { Name = "Kalem 200", Price = 200, Stock = 100, Barcode = 115 };
    // Detached Stated : Not traking state in memory.
    Console.WriteLine($"First State With Creation: {context.Entry(newProduct).State}");
    await context.AddAsync(newProduct); // ==> context.Entry(newProduct).State = EntryState.Added;
    // Added Stated : traking state in memory and state is "added".
    Console.WriteLine($"Second State With Add Function: {context.Entry(newProduct).State}");

    // await context.SaveChangesAsync();
    // Unchanged Stated : traking state in memory and state is "added".
    Console.WriteLine($"State After Save Changes : {context.Entry(newProduct).State}");

    var products = await context.Products.ToListAsync();
    products.ForEach (p =>
    {
        var state = context.Entry(p).State;
        Console.WriteLine($"{p.Id}: {p.Name} - {p.Price} - {p.Stock} , state: {state}");
    }) ;

    // Update metodu id verildigi zaman EF traker etmese bile direk isini yapar.
}

Console.WriteLine(" ");
Console.WriteLine("Ders 17: ChangeTracker / ContextId / Database");

using (var context = new AppDbContext()) {
    var products = await context.Products.AsNoTracking().ToListAsync();

    context.Products.Add(new Product() { Name = "Kalem 30", Barcode=116, Price=50, Stock=66});
    context.Products.Add(new Product() { Name = "Kalem 31", Barcode = 117, Price = 51, Stock = 67 });
    context.Products.Add(new Product() { Name = "Kalem 32", Barcode = 118, Price = 52, Stock = 68 });
    context.Products.Add(new Product() { Name = "Kalem 33", Barcode = 119, Price = 53, Stock = 69 });

    //context.SaveChanges();

}
