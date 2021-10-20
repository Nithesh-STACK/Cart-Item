using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BookingClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookAPI.Controllers
{
    public class OnlinePaymentController : Controller
    {
        public ActionResult Payment()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Payment(APIClients e)
        {
            APIClients Emplobj = new APIClients();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(e), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44344/api/Cart/OnlinePay/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    // Emplobj = JsonConvert.DeserializeObject<Emp>(apiResponse);
                }
            }
            return RedirectToAction("Thanks");
        }
    }
}
