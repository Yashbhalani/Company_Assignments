using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SourceControlFinalAssignment.Models;

namespace SourceControlFinalAssignment.DAL
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("ProductContext")
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}