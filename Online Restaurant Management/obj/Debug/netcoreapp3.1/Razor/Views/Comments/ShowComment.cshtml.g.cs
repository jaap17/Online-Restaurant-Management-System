#pragma checksum "D:\sdp2\Views\Comments\ShowComment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d993186871ff92b03bac1b45dbb9b18d0f1ba1fd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Comments_ShowComment), @"mvc.1.0.view", @"/Views/Comments/ShowComment.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\sdp2\Views\_ViewImports.cshtml"
using sdp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\sdp2\Views\_ViewImports.cshtml"
using sdp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\sdp2\Views\_ViewImports.cshtml"
using sdp.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\sdp2\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\sdp2\Views\_ViewImports.cshtml"
using RestaurantManagementSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\sdp2\Views\_ViewImports.cshtml"
using RestaurantManagementSystem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d993186871ff92b03bac1b45dbb9b18d0f1ba1fd", @"/Views/Comments/ShowComment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a01712e0eec2035ae3b9538b415afb2e3e144476", @"/Views/_ViewImports.cshtml")]
    public class Views_Comments_ShowComment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<sdp2.Models.Comments>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\sdp2\Views\Comments\ShowComment.cshtml"
  
    ViewData["Title"] = "ShowComment";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>ShowComment</h1>\r\n\r\n<div>\r\n    <h4>Comments</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "D:\sdp2\Views\Comments\ShowComment.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "D:\sdp2\Views\Comments\ShowComment.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "D:\sdp2\Views\Comments\ShowComment.cshtml"
       Write(Html.DisplayNameFor(model => model.Comment));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "D:\sdp2\Views\Comments\ShowComment.cshtml"
       Write(Html.DisplayFor(model => model.Comment));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "D:\sdp2\Views\Comments\ShowComment.cshtml"
       Write(Html.DisplayNameFor(model => model.Recipe.RecipeName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 29 "D:\sdp2\Views\Comments\ShowComment.cshtml"
       Write(Html.DisplayFor(model => model.Recipe.RecipeName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<sdp2.Models.Comments> Html { get; private set; }
    }
}
#pragma warning restore 1591
