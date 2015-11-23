using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace DataBase.Models
{
    public class Product
    {

        [Key]
        [JsonIgnore]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public byte[] Pictures { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        [JsonIgnore]
        public bool InHit { get; set; }
        [JsonIgnore]
        public bool InTop { get; set; }

    }
}
