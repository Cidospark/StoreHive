using Microsoft.AspNetCore.Mvc;
using StoreHive.API.Data;

namespace StoreHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketplaceController : ControllerBase
    {
        private readonly AppDbContext context;
        public MarketplaceController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet("getStores")]
        public IActionResult getStores()
        {
            return Ok(this.context.Stores);
        }

    }
}