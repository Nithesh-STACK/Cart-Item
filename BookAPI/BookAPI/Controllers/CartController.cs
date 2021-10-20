using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BookAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookAPI.Controllers
{
    public class CartController : Controller
    {
        string Baseurl = "https://localhost:44344/";


        public async Task<ActionResult> CartItems()
        {
            string Token = HttpContext.Request.Cookies["Token"];

            List<AddCart> cart = new List<AddCart>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44344/api/Cart/");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var CartResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    cart = JsonConvert.DeserializeObject<List<AddCart>>(CartResponse);

                }
                //returning the employee list to view  
                return View(cart);
            }
        }
        //[HttpGet]
        //public async Task<ActionResult> AddCart(int id)
        //{
        //    Book obj = new Book();
        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var response = await httpClient.GetAsync("https://localhost:44392/api/Books/" + id))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            obj = JsonConvert.DeserializeObject<Book>(apiResponse);
        //        }
        //    }
        //    return View(obj);
        //}
        //[HttpPost]
        public async Task<ActionResult> AddCart(Book e)
        {
            Book Bookobj = new Book();
            AddCart crt = new AddCart();
            crt.Id = e.Id;
            crt.Name = e.Name;

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(crt), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44344/api/Cart/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    // Bookobj = JsonConvert.DeserializeObject<Book>(apiResponse);
                }
            }
            return RedirectToAction("CartItems");
        }
    }
}
