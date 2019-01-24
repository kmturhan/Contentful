using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Contentful.Core.Configuration;
using Contentful.Models;
using Contentful.Core.Models;

namespace Contentful.Models
{
    
    public class Category
    {
        public SystemProperties Sys { get; set; }
        public string Title { get; set; }
    }
}