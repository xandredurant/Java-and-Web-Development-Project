using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Java_and_Web_Development_Project.Services
{
    public class RssFeedService
    {
        private readonly HttpClient _httpClient;

        public RssFeedService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Fetches and parses RSS feed items from a given URL
        public async Task<List<RssFeedItem>> GetNewsAsync(string feedUrl)
        {
            // Get the RSS feed as a string
            var response = await _httpClient.GetStringAsync(feedUrl);
            var document = XDocument.Parse(response);

            var items = new List<RssFeedItem>();

            // Retrieve RSS feed items
            var rssItems = document.Descendants("item").ToList();
            var itemCount = Math.Min(rssItems.Count, 3); // Limit to 3 items

            for (int i = 0; i < itemCount; i++)
            {
                var element = rssItems[i];
                var title = element.Element("title")?.Value?.Substring(0, Math.Min(30, element.Element("title")?.Value.Length ?? 0)) + "...";
                var description = element.Element("description")?.Value?.Substring(0, Math.Min(150, element.Element("description")?.Value.Length ?? 0)) + "...";
                var link = element.Element("link")?.Value;

                items.Add(new RssFeedItem
                {
                    Title = title,
                    Description = description,
                    Link = link
                });
            }

            return items;
        }
    }

    public class RssFeedItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
    }
}
