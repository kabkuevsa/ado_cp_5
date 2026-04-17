using ProductApi.Models;

namespace ProductApi.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(AppDbContext context)
        {
            if (context.Categories.Any())
            {
                return; 
            }

            var categories = new List<Category>
            {
                new Category { Name = "Электроника" },
                new Category { Name = "Одежда" },
                new Category { Name = "Книги" },
                new Category { Name = "Дом и сад" }
            };

            context.Categories.AddRange(categories);
            await context.SaveChangesAsync();

            var products = new List<Product>
            {
                new Product { Name = "Смартфон", Price = 29999.99m, CategoryId = 1 },
                new Product { Name = "Ноутбук", Price = 75000.00m, CategoryId = 1 },
                new Product { Name = "Футболка", Price = 1500.00m, CategoryId = 2 },
                new Product { Name = "Джинсы", Price = 3500.00m, CategoryId = 2 },
                new Product { Name = "Программирование на C#", Price = 2500.00m, CategoryId = 3 },
                new Product { Name = "Лампа настольная", Price = 1200.00m, CategoryId = 4 }
            };

            context.Products.AddRange(products);
            await context.SaveChangesAsync();
        }
    }
}