#pragma checksum "D:\sdp2\Views\Comments\ViewComments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2a6a032b1852e94bc5c0772fcf3a35fe15bce298"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Comments_ViewComments), @"mvc.1.0.view", @"/Views/Comments/ViewComments.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a6a032b1852e94bc5c0772fcf3a35fe15bce298", @"/Views/Comments/ViewComments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a01712e0eec2035ae3b9538b415afb2e3e144476", @"/Views/_ViewImports.cshtml")]
    public class Views_Comments_ViewComments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<sdp2.Models.Comments>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\sdp2\Views\Comments\ViewComments.cshtml"
  
    ViewData["Title"] = "ViewComments";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>ViewComments</h1>\r\n\r\n<p>\r\n    <h1>Comments for ");
#nullable restore
#line 10 "D:\sdp2\Views\Comments\ViewComments.cshtml"
                Write(ViewBag.RecipeName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Recipe</h1>\r\n</p>\r\n\r\n");
#nullable restore
#line 13 "D:\sdp2\Views\Comments\ViewComments.cshtml"
 foreach (var item in Model) 
{

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card m-2\">\r\n            <div class=\"card-header\">\r\n                <h1>Username:");
#nullable restore
#line 17 "D:\sdp2\Views\Comments\ViewComments.cshtml"
                        Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n            </div>\r\n            <div class=\"card-body\">\r\n                <h3>\r\n                    Comment<br />\r\n                    ");
#nullable restore
#line 22 "D:\sdp2\Views\Comments\ViewComments.cshtml"
               Write(item.Comment);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </h3>\r\n            </div>\r\n            <div class=\"card-footer\">\r\n                ");
#nullable restore
#line 26 "D:\sdp2\Views\Comments\ViewComments.cshtml"
           Write(ViewBag.RecipeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 29 "D:\sdp2\Views\Comments\ViewComments.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    \r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<sdp2.Models.Comments>> Html { get; private set; }
    }
}
#pragma warning restore 1591
