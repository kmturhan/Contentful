using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Contentful.Core.Models;
using Newtonsoft.Json.Linq;
namespace Contentful.Models
{
    public class Pages
    {
        public SystemProperties Sys { get; set; }
        public string PageName { get; set; }
        public JArray modules { get; set; }
        
    }
}