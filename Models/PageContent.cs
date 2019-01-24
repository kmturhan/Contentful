using Contentful.Core.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contentful.Models
{
    public class PageContent
    {
        public string title { get; set; }
        public Document text { get; set; }
        public List<Asset> images { get; set; }
    }
    
}