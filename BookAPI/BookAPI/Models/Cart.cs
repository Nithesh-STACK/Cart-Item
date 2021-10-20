using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public class AddCart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int? Price { get; set; }
        public string Photo { get; set; }
        public string PlotDescription { get; set; }

        public virtual Book IdNavigation { get; set; }
    }
}
