using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contentful.Models
{
    public class Homepage
    {
        public List<Product> Urun { get; set; }
        public List<Category> Kategori { get; set; }
    }
}