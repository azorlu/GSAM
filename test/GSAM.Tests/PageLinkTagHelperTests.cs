using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Moq;
using GSAM.Infrastructure;
using GSAM.Models.ViewModels;
using Xunit;

namespace GSAM.Tests
{
    public class PageLinkTagHelperTests
    {
        [Fact]
        public void Can_Generate_Page_Links()
        {
            var urlHelper = new Mock<IUrlHelper>();
            urlHelper.SetupSequence(x => 
                x.Action(It.IsAny<UrlActionContext>()))
                .Returns("App/Page1")
                .Returns("App/Page2")
                .Returns("App/Page3");
            var urlHelperFactory = new Mock<IUrlHelperFactory>();
            urlHelperFactory.Setup(f => 
                f.GetUrlHelper(It.IsAny<ActionContext>())).Returns(urlHelper.Object);
            PageLinkTagHelper helper = new PageLinkTagHelper(urlHelperFactory.Object)
            {
                PageModel = new PagingInfo
                {
                    CurrentPage = 2,
                    TotalItems = 8,
                    ItemsPerPage = 3
                },
                PageAction = "App"
            };
            TagHelperContext thc = new TagHelperContext(
                new TagHelperAttributeList(), new Dictionary<object, object>(), "");
            var content = new Mock<TagHelperContent>();
            TagHelperOutput output = new TagHelperOutput("div", 
                new TagHelperAttributeList(), (cache, encoder) => Task.FromResult(content.Object));
            
            helper.Process(thc, output);
            
            Assert.Equal(@"<a href=""App/Page1"">1</a>"
                        + @"<a href=""App/Page2"">2</a>"
                        + @"<a href=""App/Page3"">3</a>",
            output.Content.GetContent());
        }

    }
}
