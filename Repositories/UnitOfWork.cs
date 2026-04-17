using ProductApi.Data;
using ProductApi.Interfaces;
using ProductApi.Models;

namespace ProductApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IRepository<Product> _products = null!;
        private IRepository<Category> _categories = null!;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IRepository<Product> Products
        {
            get { return _products ??= new Repository<Product>(_context); }
        }

        public IRepository<Category> Categories
        {
            get { return _categories ??= new Repository<Category>(_context); }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}