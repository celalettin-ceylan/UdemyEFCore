// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using UdemyEFCore.DatabaseFirstByScaffold.Models;

Console.WriteLine("Hello, World!");

// Db hazir ise Scaffold ile modelleri olustur ama daha sonra code-first yaklasim ile devam etmek gerekmektedir. Hayatiniz hata ayiklamak ile gecer...

using (var context = new UdemyEFCoreDatabaseFirstDbContext()) {

    var products = await context.Products.ToListAsync();

    products.ForEach(
        p => Console.WriteLine($"{p.Id}: {p.Name} - {p.Price} - {p.Stock}")
        );
}
