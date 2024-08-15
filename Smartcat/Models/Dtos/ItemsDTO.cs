using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Smartcat.Models.Dtos
{
    public class Item
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class ItemsDTO
    {
        public List<Item> items { get; set; }
    }
}
