using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contentful.Models;
using Contentful.Core.Models;
namespace Contentful.Models
{
    public class User
    {
        public SystemProperties sys { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
    }
}