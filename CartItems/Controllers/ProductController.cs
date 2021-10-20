using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartItems.KaniniModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CartItems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        public static stationaryContext db = new stationaryContext();

        [HttpGet]
        public async Task<IActionResult> ProductCart()
        {
            return Ok(await db.ProductsCarts.ToListAsync());
        }
        [HttpPost]

        public async Task<IActionResult> InsertPro(ProductsCart b)
        {
            db.ProductsCarts.Add(b);
            await db.SaveChangesAsync();
            return Ok();
                                     
        }
        [HttpDelete]
        [Route("{id}")]

        public async Task<ActionResult<ProductsCart>> DeletePro(int id)
        {
            ProductsCart b = db.ProductsCarts.Find(id);
            db.ProductsCarts.Remove(b);
            await db.SaveChangesAsync();
            return Ok();

        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProductsCart>> GetProById(int id)
        {
            ProductsCart b = await db.ProductsCarts.FindAsync(id);
            return Ok(b);
        }
    }
}
