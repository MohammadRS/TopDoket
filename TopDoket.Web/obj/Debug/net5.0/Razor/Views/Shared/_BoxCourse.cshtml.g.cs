#pragma checksum "C:\Users\P\Desktop\Top_Project\TopDoket\TopDoket.Web\Views\Shared\_BoxCourse.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c2e7350399987751824789088c695a1aa18dc189"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__BoxCourse), @"mvc.1.0.view", @"/Views/Shared/_BoxCourse.cshtml")]
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
#line 1 "C:\Users\P\Desktop\Top_Project\TopDoket\TopDoket.Web\Views\_ViewImports.cshtml"
using TopDoket.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\P\Desktop\Top_Project\TopDoket\TopDoket.Web\Views\_ViewImports.cshtml"
using TopDoket.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2e7350399987751824789088c695a1aa18dc189", @"/Views/Shared/_BoxCourse.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e9bec32ddc0cde8ebcb2dfc22f809ca2f6b06c9", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__BoxCourse : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TopDoket.Core.DTOs.Course.ShowCourseListItemViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!-- col -->\r\n<div class=\"col-lg-3 col-md-4 col-sm-6 col-xs-12 term-col\">\r\n    <article>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 162, "\"", 196, 2);
            WriteAttributeValue("", 169, "/ShowCourse/", 169, 12, true);
#nullable restore
#line 5 "C:\Users\P\Desktop\Top_Project\TopDoket\TopDoket.Web\Views\Shared\_BoxCourse.cshtml"
WriteAttributeValue("", 181, Model.CourseId, 181, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-layer\"><img");
            BeginWriteAttribute("src", " src=\"", 220, "\"", 256, 2);
            WriteAttributeValue("", 226, "/course/thumb/", 226, 14, true);
#nullable restore
#line 5 "C:\Users\P\Desktop\Top_Project\TopDoket\TopDoket.Web\Views\Shared\_BoxCourse.cshtml"
WriteAttributeValue("", 240, Model.ImageName, 240, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></a>\r\n        <h2><a");
            BeginWriteAttribute("href", " href=\"", 278, "\"", 312, 2);
            WriteAttributeValue("", 285, "/ShowCourse/", 285, 12, true);
#nullable restore
#line 6 "C:\Users\P\Desktop\Top_Project\TopDoket\TopDoket.Web\Views\Shared\_BoxCourse.cshtml"
WriteAttributeValue("", 297, Model.CourseId, 297, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> ");
#nullable restore
#line 6 "C:\Users\P\Desktop\Top_Project\TopDoket\TopDoket.Web\Views\Shared\_BoxCourse.cshtml"
                                              Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </a></h2>\r\n        <span> ");
#nullable restore
#line 7 "C:\Users\P\Desktop\Top_Project\TopDoket\TopDoket.Web\Views\Shared\_BoxCourse.cshtml"
           Write((Model.Price==0)?"رایگان":Model.Price.ToString("#,0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n\r\n");
#nullable restore
#line 9 "C:\Users\P\Desktop\Top_Project\TopDoket\TopDoket.Web\Views\Shared\_BoxCourse.cshtml"
          
            var duration = new TimeSpan(Model.CourseEpisodes.Sum(e => e.EpisodeTime.Ticks));
            var th = (int)duration.TotalHours;
            var tm = (int)duration.TotalMinutes - (th * 60);
            var ts = "00";

        

#line default
#line hidden
#nullable disable
            WriteLiteral("        <i>");
#nullable restore
#line 16 "C:\Users\P\Desktop\Top_Project\TopDoket\TopDoket.Web\Views\Shared\_BoxCourse.cshtml"
       Write($"{th}:{tm}:{ts}");

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n    </article>\r\n</div>\r\n<!-- /col -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TopDoket.Core.DTOs.Course.ShowCourseListItemViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
