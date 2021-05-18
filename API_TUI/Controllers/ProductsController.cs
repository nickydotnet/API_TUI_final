using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_TUI.Model;
using API_TUI.Tools;
using Microsoft.Extensions.Logging;

namespace API_TUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly TUI_Context _context;

        public ProductsController(TUI_Context context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductItems()
        {
            return await _context.ProductItems.ToListAsync();
        }

        // GET: api/Products/5
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.ProductItems.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
        
        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (product.DateValidityStart < product.DateValidityEnd)
            {
                _context.ProductItems.Add(product);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetProduct", new { id = product.Id }, product);
            }

            return BadRequest("Error");
        }

        private bool ProductExists(int id)
        {
            return _context.ProductItems.Any(e => e.Id == id);
        }
    }
}
