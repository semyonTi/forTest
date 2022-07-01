using ConsoleApp5;
using Microsoft.EntityFrameworkCore;

using (ApplicationContext db = new ApplicationContext())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    Product apple = new Product { Name = "apple" };
    Product orange = new Product { Name = "orange" };
    db.Products.AddRange(apple, orange);

    ProductType fruit = new ProductType { Name = "fruit" };
   
    db.ProductTypes.AddRange(fruit);
    apple.ProductTypes.Add(fruit);

    db.SaveChanges();

    var productsType = db.Products.Include(c => c.ProductTypes).ToList();
    foreach (var item in productsType)
    {
        Console.WriteLine(item.Name);
        foreach (var item1 in item.ProductTypes)
        {
            Console.WriteLine(item1.Name);
        }
        Console.WriteLine("--------------------");
    }
}
