#pragma checksum "C:\Users\P\Desktop\Top_Project\TopDoket\TopDoket.Web\Views\Shared\_ForgotPassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f781d97704e8834210d0bf11eaedcd14ca11e982"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ForgotPassword), @"mvc.1.0.view", @"/Views/Shared/_ForgotPassword.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f781d97704e8834210d0bf11eaedcd14ca11e982", @"/Views/Shared/_ForgotPassword.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e9bec32ddc0cde8ebcb2dfc22f809ca2f6b06c9", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ForgotPassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TopDoket.DataLayer.Entities.User.User>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div style=\"direction: rtl; padding: 20px\">\r\n    <h2>");
#nullable restore
#line 4 "C:\Users\P\Desktop\Top_Project\TopDoket\TopDoket.Web\Views\Shared\_ForgotPassword.cshtml"
   Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" عزیز !</h2>\r\n    <p>\r\n        جهت بازیابی حساب کاربری خود روی لینک زیر کلیک کنید\r\n    </p>\r\n    <p>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 228, "\"", 298, 2);
            WriteAttributeValue("", 235, "https://localhost:44367/Account/ResetPassword/", 235, 46, true);
#nullable restore
#line 9 "C:\Users\P\Desktop\Top_Project\TopDoket\TopDoket.Web\Views\Shared\_ForgotPassword.cshtml"
WriteAttributeValue("", 281, Model.ActiveCode, 281, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">بازیابی کلمه عبور</a>\r\n    </p>\r\n</div>\r\n  ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TopDoket.DataLayer.Entities.User.User> Html { get; private set; }
    }
}
#pragma warning restore 1591
