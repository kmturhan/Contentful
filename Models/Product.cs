using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using Contentful.Core.Models;
using Newtonsoft.Json.Linq;
using Contentful.Models;
using Contentful.Core.Configuration;

namespace Contentful.Models
{
    
    public class Product
    {
        public SystemProperties Sys { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public Document Description { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public JArray categoryRef { get; set; }
        public Asset image { get; set; }
        
    }

    
}