using Microsoft.AspNetCore.Components;
using MyApplication.Core.Data.Demo;
using MyApplication.Core.Data.Demo.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyApplication.UI.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        private DemoDbContext DemoDbContext { get; set; }

        public List<Example> examples;

        protected override void OnInitialized()
        {
            examples = DemoDbContext
                .Example
                .ToList();
        }
    }
}
