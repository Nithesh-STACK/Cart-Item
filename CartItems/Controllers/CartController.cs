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
    public class CartController : Controller
    {
        public static stationaryContext db = new stationaryContext();

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            return Ok(await db.AddCarts.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> InsertItems(AddCart b)
        {
            db.AddCarts.Add(b);
            await db.SaveChangesAsync();
            return Ok();

        }
        [HttpGet]
        [Route("OnlinePay")]
        public async Task<IActionResult> OnlinePay()
        {
            return Ok(await db.PaymentDetails.ToListAsync());
        }
        [HttpPost]
        [Route("OnlinePay")]

        public async Task<IActionResult> InsertPayment(PaymentDetail b)
        {
            db.PaymentDetails.Add(b);
            await db.SaveChangesAsync();
            return Ok();

        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<AddCart>> Delete(int id)
        {
            AddCart b = db.AddCarts.Find(id);
            db.AddCarts.Remove(b);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<AddCart>> GetBookById(int id)
        {
            AddCart b = await db.AddCarts.FindAsync(id);
            return Ok(b);
        }
        
    

}
}
