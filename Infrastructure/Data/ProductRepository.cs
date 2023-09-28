using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _storeContext;

        public ProductRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync(CancellationToken cancellationToken)
        {
            return await _storeContext.ProductBrands.ToListAsync(cancellationToken);
        }

        public async Task<Product?> GetProductByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _storeContext.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .FirstOrDefaultAsync(p => p.ProductId == id, cancellationToken);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync(CancellationToken cancellationToken)
        {
            return await _storeContext.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync(CancellationToken cancellationToken)
        {
            return await _storeContext.ProductTypes.ToListAsync(cancellationToken);
        }
    }
}