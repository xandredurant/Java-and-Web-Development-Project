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

        public async Task<List<RssFeedItem>> GetNewsAsync(string feedUrl)
        {
            var response = await _httpClient.GetStringAsync(feedUrl);
            var document = XDocument.Parse(response);

            var items = new List<RssFeedItem>();
            if (document.Descendants().Count() < 3) {
                foreach (var element in document.Descendants("item"))
                {
                    var title = element.Element("title")?.Value.Substring(0,30) + "...";
                    var description = element.Element("description")?.Value.Substring(0, 150) + "...";
                    var link = element.Element("link")?.Value;

                    items.Add(new RssFeedItem
                    {
                        Title = title,
                        Description = description,
                        Link = link
                    });
                }
            }
            else
            {
                for( int k = 0; k < 3;  k++)
                {
                    var element = document.Descendants("item").ToArray()[k];
                    var title = element.Element("title")?.Value.Substring(0, 30) + "...";
                    var description = element.Element("description")?.Value.Substring(0, 150) + "...";
                    var link = element.Element("link")?.Value;

                    items.Add(new RssFeedItem
                    {
                        Title = title,
                        Description = description,
                        Link = link
                    });
                }
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
