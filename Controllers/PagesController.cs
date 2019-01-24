using Contentful.Core;
using Contentful.Core.Configuration;
using Contentful.Core.Models;
using Contentful.Core.Search;
using Contentful.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Contentful.Controllers
{
    public class PagesController : Controller
    {
        // GET: Pages
        //public async Task<ActionResult> Index(string PageID)
        //{
        //    HttpClient httpClient = new HttpClient();
        //    var options = new ContentfulOptions
        //    {
        //        DeliveryApiKey = "4df4c5c7ed276605d36b9d880f1455aea05fe9b47e2da6acf518c0771d300625",
        //        PreviewApiKey = "3aaec008db04a17e144539715f539354ff73cf8d82c2548c3045bbcfc2ee32a2",
        //        SpaceId = "bda2gc49gm0w"
        //    };

        //    var client = new ContentfulClient(httpClient, options);
        //    var PageInfo = await client.GetEntry<Pages>(PageID);
        //    List<string> CurrentPageEntries = new List<string>();
        //    foreach(var item in PageInfo.modules) { CurrentPageEntries.Add(item["sys"]["id"].ToString()); }

        //    return View();
        //}

        public async Task<ActionResult> About()
        {
            HttpClient httpClient = new HttpClient();
            var options = new ContentfulOptions
            {
                DeliveryApiKey = "4df4c5c7ed276605d36b9d880f1455aea05fe9b47e2da6acf518c0771d300625",
                PreviewApiKey = "3aaec008db04a17e144539715f539354ff73cf8d82c2548c3045bbcfc2ee32a2",
                SpaceId = "bda2gc49gm0w"
            };

            var client = new ContentfulClient(httpClient, options);


            var PageInfo = await client.GetEntry<Pages>("67fZc5ATyn7AMbKS7W938A");
            List<PageContent> currentPageContents = new List<PageContent>();

            foreach (var item in PageInfo.modules)
            {
                currentPageContents.Add(await client.GetEntry<PageContent>(item["sys"]["id"].ToString()));
            }

            return View(currentPageContents);
        }

        public async Task<ActionResult> Contact()
        {
            HttpClient httpClient = new HttpClient();
            var options = new ContentfulOptions
            {
                DeliveryApiKey = "4df4c5c7ed276605d36b9d880f1455aea05fe9b47e2da6acf518c0771d300625",
                PreviewApiKey = "3aaec008db04a17e144539715f539354ff73cf8d82c2548c3045bbcfc2ee32a2",
                SpaceId = "bda2gc49gm0w"
            };

            var client = new ContentfulClient(httpClient, options);
            var PageInfo = await client.GetEntry<Pages>("6pe3lPKCzpsyz9nZBpJzbr");
            List<PageContent> currentPageContents = new List<PageContent>();

            foreach (var item in PageInfo.modules)
            {
                currentPageContents.Add(await client.GetEntry<PageContent>(item["sys"]["id"].ToString()));
            }

            return View(currentPageContents);
        }
    }
}