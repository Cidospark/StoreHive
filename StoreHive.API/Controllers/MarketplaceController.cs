using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreHive.API.Data;
using StoreHive.API.Dtos;

namespace StoreHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketplaceController : ControllerBase
    {
        private readonly IProductRepository product;
        private readonly IMapper mapper;
        private readonly AppDbContext context;
        public MarketplaceController(IProductRepository product, IMapper mapper, AppDbContext context)
        {
            this.context = context;
            this.mapper = mapper;
            this.product = product;
        }

        [HttpGet("getProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await this.product.GetAllProducts();           


            if (products == null)
                return BadRequest();

            // map objects
            var productToReturn = this.mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productToReturn);
        }

    }
}