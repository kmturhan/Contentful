using Contentful.Core;
using Contentful.Core.Configuration;
using Contentful.Core.Search;
using Contentful.Models;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Contentful.Controllers
{
    public class HomeController : Controller
    {

        public async Task<ActionResult> Index()
        {
            if(Session["username"] != null) { ViewBag.Session = Session["username"].ToString(); } else { ViewBag.Session = "Contentful"; }
            
            HttpClient httpClient = new HttpClient();
            var options = new ContentfulOptions
            {
                DeliveryApiKey = "4df4c5c7ed276605d36b9d880f1455aea05fe9b47e2da6acf518c0771d300625",
                PreviewApiKey = "3aaec008db04a17e144539715f539354ff73cf8d82c2548c3045bbcfc2ee32a2",
                SpaceId = "bda2gc49gm0w"
            };

            var client = new ContentfulClient(httpClient, options);

            var AllCategories = await client.GetEntries(QueryBuilder<Category>.New.ContentTypeIs("category"));
            var AllCategoryItems = await client.GetEntries(QueryBuilder<Product>.New.ContentTypeIs("categoryItems"));

            Homepage model = new Homepage();
            model.Kategori = AllCategories.Items.ToList();
            model.Urun = AllCategoryItems.Items.ToList();

            return View(model);
        }
        

        public async Task<ActionResult> ProductDetails(string productID)
        {
            HttpClient httpClient = new HttpClient();
            var options = new ContentfulOptions
            {
                DeliveryApiKey = "4df4c5c7ed276605d36b9d880f1455aea05fe9b47e2da6acf518c0771d300625",
                PreviewApiKey = "3aaec008db04a17e144539715f539354ff73cf8d82c2548c3045bbcfc2ee32a2",
                SpaceId = "bda2gc49gm0w"
            };
            var client = new ContentfulClient(httpClient, options);

            var ProductDetail = await client.GetEntries(QueryBuilder<Product>.New.ContentTypeIs("categoryItems").FieldEquals(f => f.Sys.Id,productID));
            return View(ProductDetail.ToList());
        }

        public async Task<ActionResult> Category(string categoryID)
        {
            
            HttpClient httpClient = new HttpClient();
            var options = new ContentfulOptions
            {
                DeliveryApiKey = "4df4c5c7ed276605d36b9d880f1455aea05fe9b47e2da6acf518c0771d300625",
                PreviewApiKey = "3aaec008db04a17e144539715f539354ff73cf8d82c2548c3045bbcfc2ee32a2",
                SpaceId = "bda2gc49gm0w"
            };
            var client = new ContentfulClient(httpClient, options);

            var AllItems = await client.GetEntries(QueryBuilder<Product>.New.ContentTypeIs("categoryItems"));
            var FilterCategoryItems = AllItems.Where(c => c.categoryRef.Any(x => string.Equals(x["$ref"].ToString(), categoryID)));
            var AllCategories = await client.GetEntries(QueryBuilder<Category>.New.ContentTypeIs("category"));

            var model = new Homepage();
            model.Urun = FilterCategoryItems.ToList();
            model.Kategori = AllCategories.ToList();
            return View("Index",model);
        }

    }
}