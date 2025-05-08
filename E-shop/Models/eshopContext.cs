using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E_shop.Models
{
    public class eshopContext : DbContext
    {
        public eshopContext() : base("name = eshopDBb") { }

        public DbSet<Produit> Produit { get; set; }

    }
}