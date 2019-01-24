using Contentful.Core;
using Contentful.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Contentful.Models;
using Contentful.Core.Models;
using System.Threading.Tasks;
using Contentful.Core.Search;

namespace Contentful.Controllers
{
    public class StateController : Controller
    {
        // GET: State
        public ActionResult Index()
        {

            //var options = new ContentfulOptions
            //{
            //    DeliveryApiKey = "4df4c5c7ed276605d36b9d880f1455aea05fe9b47e2da6acf518c0771d300625",
            //    PreviewApiKey = "3aaec008db04a17e144539715f539354ff73cf8d82c2548c3045bbcfc2ee32a2",
            //    SpaceId = "bda2gc49gm0w"

            //};



            return View();
        }

        public async Task<ActionResult> Register()
        {
            HttpClient httpClient = new HttpClient();
            var options = new ContentfulOptions
            {
                DeliveryApiKey = "4df4c5c7ed276605d36b9d880f1455aea05fe9b47e2da6acf518c0771d300625",
                PreviewApiKey = "3aaec008db04a17e144539715f539354ff73cf8d82c2548c3045bbcfc2ee32a2",
                SpaceId = "bda2gc49gm0w"
            };

            var client = new ContentfulClient(httpClient, options);

            List<string> Cities = new List<string>();
            var AllCategories = await client.GetContentType("users");
            foreach (var fields in AllCategories.Fields)
            {
                if (fields.Id == "allCity")
                {
                    Cities = ((Contentful.Core.Models.Management.InValuesValidator)fields.Items.Validations[0]).RequiredValues;
                }
            }
            HttpContext.Cache.Add("City", Cities, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(1, 0, 0), System.Web.Caching.CacheItemPriority.Normal, null);


            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UserControl(string username, string password)
        {
            HttpClient httpClient = new HttpClient();
            var options = new ContentfulOptions
            {
                DeliveryApiKey = "4df4c5c7ed276605d36b9d880f1455aea05fe9b47e2da6acf518c0771d300625",
                PreviewApiKey = "3aaec008db04a17e144539715f539354ff73cf8d82c2548c3045bbcfc2ee32a2",
                SpaceId = "bda2gc49gm0w"
            };
            var client = new ContentfulClient(httpClient, options);

            var AllItems = await client.GetEntries(QueryBuilder<User>.New.ContentTypeIs("users"));
            foreach (var item in AllItems)
            {
                if (item.Username.ToLower() == username.ToLower() && item.Password.ToLower() == password.ToLower() && username != null && password != null)
                {
                    Session["username"] = username;
                    return RedirectToAction("Index", "Home");
                }
                
            }
            return RedirectToAction("Index", "State");
        }

        [HttpPost]
        public async Task<ActionResult> UserAdd(string username, string password, Array City)
        {

            HttpClient httpClient = new HttpClient();
            var client = new ContentfulManagementClient(httpClient, "CFPAT-0188062dc4d4c5bdc61c744ffae9f600e56164b944e1a6c8d422ad1a0257525d", "bda2gc49gm0w");

            var entry = new Entry<dynamic>();
            entry.SystemProperties = new SystemProperties();
            entry.SystemProperties.Id = Guid.NewGuid().ToString();
            entry.Fields = new
            {
                username = new Dictionary<string, string>()
                {
                    {"en-US",username}
                },
                password = new Dictionary<string, string>()
                {
                    {"en-US",password}
                },
                allCity = new Dictionary<string, Array>()
                {
                    {"en-US", City}
                }
            };

            await client.CreateOrUpdateEntry(entry, contentTypeId: "users");
            await client.PublishEntry(entry.SystemProperties.Id, 1);


            return View("Index");
        }
    }
}