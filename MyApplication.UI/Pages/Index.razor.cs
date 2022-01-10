namespace MyApplication.UI.Pages
{
    using Microsoft.AspNetCore.Components;
    using MyApplication.Core.Data.Demo;
    using MyApplication.Core.Data.Demo.Models;
    using System.Collections.Generic;
    using System.Linq;

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
