using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductClient.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace ProductClient.Controllers
{
    public class ProductController : Controller
    {
        //string Baseurl = "https://localhost:44387/";

        public async Task<ActionResult> Index()
        {
            List<Pro> ProductInfo = new List<Pro>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
               // client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44387/api/ProductsBooking/");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    ProductInfo = JsonConvert.DeserializeObject<List<Pro>>(ProResponse);

                }
                //returning the employee list to view  
                return View(ProductInfo);
            }
        }
       
    }

}


    

