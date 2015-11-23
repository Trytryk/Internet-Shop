using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}

