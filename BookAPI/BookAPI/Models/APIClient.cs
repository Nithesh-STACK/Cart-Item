using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models
{
        public  class Book
        {
        [Key]

        public int Id { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public int? Price { get; set; }
            public string Photo { get; set; }
            public string PlotDescription { get; set; }
        }
  
        public class ShipmentDetail
        {
            public string BuyersName { get; set; }
            public int? Age { get; set; }
            public string AddressDetails { get; set; }
            public double MobileNumber { get; set; }
        }
    public class PaymentDetail
    {
        public string CardHolderName { get; set; }
        public double? DebitCardNumber { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int CvvPin { get; set; }
    }
}
    

