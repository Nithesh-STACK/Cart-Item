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
    public class ChaatController : Controller
    {
        public static stationaryContext db = new stationaryContext();

        [HttpGet]
        public async Task<IActionResult> ChatsCart()
        {
            return Ok(await db.ChaatsCarts.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> ChatsInsert(ChaatsCart b)
        {
            db.ChaatsCarts.Add(b);
            await db.SaveChangesAsync();
            return Ok();

        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ChaatsCart>> Delete(int id)
        {
            ChaatsCart b = db.ChaatsCarts.Find(id);
            db.ChaatsCarts.Remove(b);
            await db.SaveChangesAsync();
            return Ok();

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ChaatsCart>> GetchatById(int id)
        {
            ChaatsCart b = await db.ChaatsCarts.FindAsync(id);
            return Ok(b);
        }
    }
}

