using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using Core.Entities;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(CancellationToken cancellationToken)
        {
            var products = await _repo.GetProductsAsync(cancellationToken);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product?>> GetProduct(int id, CancellationToken cancellationToken)
        {
            return await _repo.GetProductByIdAsync(id, cancellationToken);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProductBrands(CancellationToken cancellationToken)
        {
            var productBrands = await _repo.GetProductBrandsAsync(cancellationToken);
            return Ok(productBrands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProductTypes(CancellationToken cancellationToken)
        {
            return Ok(await _repo.GetProductTypesAsync(cancellationToken));
        }
    }
}