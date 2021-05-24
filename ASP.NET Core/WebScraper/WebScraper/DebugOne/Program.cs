using AngleSharp;
using EasyTravel.Services.Models;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DebugOne
{
    class Program
    {
       private const string BaseUrl = "https://pochivka.bg/apartamenti-a4/{i}";
       
        static async Task Main(string[] args)
        {

            ConcurrentBag<PropertyDto> concurrentBag = await ScrapeRecipes(1, 10);
            Console.WriteLine($"Scraped recipes: {concurrentBag.Count}");

        }
        public static async Task<ConcurrentBag<PropertyDto>> ScrapeRecipes(int fromId, int toId)
        {

            var concurrentBag = new ConcurrentBag<PropertyDto>();
            Parallel.For(fromId, toId + 1, async i =>
            {
                try
                {
                    var property = await GetProperty(i);
                    concurrentBag.Add(property);
                }
                catch
                {
                    // ignored
                }
            });
            return concurrentBag;
        }

        private static async Task <PropertyDto> GetProperty(int id)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            var url = string.Format(BaseUrl, id);

            var document = context
                .OpenAsync(url)
                .GetAwaiter()
                .GetResult();

            if (document.StatusCode == HttpStatusCode.NotFound ||
                document.DocumentElement.OuterHtml.Contains("Тази страница не е намерена"))
            {
                throw new InvalidOperationException();
            }

            var elements = document.QuerySelectorAll(".result-item");
            var links = new ConcurrentBag<string>();

            Parallel.ForEach(elements, item =>
            {
                var link = item.QuerySelector(".thumb > a ").GetAttribute("href");
                links.Add(link);
            });

            links.ToList();

            var property = new PropertyDto();

            foreach (var l in links)
            {

                var hhh = "https:" + l;
                //var page = await context.OpenAsync(hhh);
                var page = context
                .OpenAsync(url)
                .GetAwaiter()
                .GetResult();

                property.OriginalUrl = hhh;
                var category = page.QuerySelector("#breadcrumbs > ul > li:nth-child(2) > a");
                property.CategoryName = category.TextContent.TrimStart();

                var titlePage = page.QuerySelector(" .page-title > .pull-left > h1");
                property.Name = titlePage.TextContent;
                var phone = page.QuerySelector("#popup_phone > div.content > div.pull-left");
                property.PhoneNumber = phone.TextContent.TrimStart();
                var address = page.QuerySelector("#popup_address > div.content");
                property.Address = address.TextContent.TrimStart();
                var city = page.QuerySelector("body > div.container > div > div.property-view.vip > div:nth-child(1) > div > div > div > div.sub-title");
                property.CityName = city.TextContent;
                var descriptionPage = page.QuerySelector("div.col-4.margin-0.pull-right > div.description");
           
                property.Description = descriptionPage.TextContent;
                var amenities = page.QuerySelectorAll("div.col-4 > div.extras > ul")
                   .Select(x => x.TextContent)
                  .ToList();

                Console.WriteLine(amenities[2]);
                property.Amenities.AddRange(amenities);

                var tablewithInfo = page.QuerySelectorAll("#prices > table > tbody > tr > td").Select(x => x.TextContent)
                    .ToList();
                property.SummerPrice = decimal.Parse(tablewithInfo[3]);
                property.WinterPrice = decimal.Parse(tablewithInfo[5]);
                property.Capacity = int.Parse(tablewithInfo[1]);

                var imgElements = page.GetElementsByClassName("gallery-slider");

                foreach (var img in imgElements)
                {
                    var image = img.QuerySelectorAll("img");
                    foreach (var one in image)
                    {
                        var linkOfPhoto = one.GetAttribute("content");
                        property.Images.Add(linkOfPhoto);
                    }
                }
            }

            return property;
        }
    }
}
