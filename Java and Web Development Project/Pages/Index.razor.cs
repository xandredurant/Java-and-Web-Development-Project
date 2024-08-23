using Java_and_Web_Development_Project.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Java_and_Web_Development_Project.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        public RssFeedService RssFeedService { get; set; }

        private List<RssFeedItem> feedItems;

        protected override async Task OnInitializedAsync()
        {
            feedItems = await RssFeedService.GetNewsAsync("https://www.solarpowerworldonline.com/category/industry-news/feed/");
        }
    }
}
