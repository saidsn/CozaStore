#pragma checksum "C:\Users\OMEN\Desktop\Final-Teqdimat\Backend\End_Project\End_Project\Areas\AdminArea\Views\Contact\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ab22190cb855a459049d1313a6fd2a2d8c0a2188"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_AdminArea_Views_Contact_Index), @"mvc.1.0.view", @"/Areas/AdminArea/Views/Contact/Index.cshtml")]
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
#line 1 "C:\Users\OMEN\Desktop\Final-Teqdimat\Backend\End_Project\End_Project\Areas\AdminArea\Views\_ViewImports.cshtml"
using End_Project.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\OMEN\Desktop\Final-Teqdimat\Backend\End_Project\End_Project\Areas\AdminArea\Views\_ViewImports.cshtml"
using End_Project.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\OMEN\Desktop\Final-Teqdimat\Backend\End_Project\End_Project\Areas\AdminArea\Views\_ViewImports.cshtml"
using End_Project.ViewModels.Product;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\OMEN\Desktop\Final-Teqdimat\Backend\End_Project\End_Project\Areas\AdminArea\Views\_ViewImports.cshtml"
using End_Project.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\OMEN\Desktop\Final-Teqdimat\Backend\End_Project\End_Project\Areas\AdminArea\Views\_ViewImports.cshtml"
using End_Project.ViewModels.BlogViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab22190cb855a459049d1313a6fd2a2d8c0a2188", @"/Areas/AdminArea/Views/Contact/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8463fa50a7c95ebbeb55e3d6a6ee666289353497", @"/Areas/AdminArea/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_AdminArea_Views_Contact_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Contact>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\OMEN\Desktop\Final-Teqdimat\Backend\End_Project\End_Project\Areas\AdminArea\Views\Contact\Index.cshtml"
  
    ViewData["Title"] = "Index";
    int count = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Link", async() => {
                WriteLiteral("\r\n\r\n    <link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta2/css/all.min.css\" />\r\n");
            }
            );
            WriteLiteral(@"

<div class=""container"">
    <div class=""row"">
        <div class=""col-lg-12 grid-margin stretch-card"">
            <div class=""card"">
                <div class=""card-body"">
                    <h3 style=""text-align:center;color:#505668""> - Contact Index -</h3>
                    <div class=""table-responsive pt-3"">
                        <table class=""table table-bordered table-hover border-dark"">
                            <thead style=""background:#505668;color:wheat"">

                                <tr>
                                    <th>
                                        #
                                    </th>
                                    <th>
                                        Name
                                    </th>
                                    <th>
                                        Email
                                    <th>
                                        Subject
                                    <th>
            ");
            WriteLiteral(@"                            Message
                                    </th>
                                    <th style=""text-align:center"">
                                        Settings
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 43 "C:\Users\OMEN\Desktop\Final-Teqdimat\Backend\End_Project\End_Project\Areas\AdminArea\Views\Contact\Index.cshtml"
                                 foreach (var contact in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 47 "C:\Users\OMEN\Desktop\Final-Teqdimat\Backend\End_Project\End_Project\Areas\AdminArea\Views\Contact\Index.cshtml"
                                       Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 50 "C:\Users\OMEN\Desktop\Final-Teqdimat\Backend\End_Project\End_Project\Areas\AdminArea\Views\Contact\Index.cshtml"
                                       Write(Html.Raw(contact.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 53 "C:\Users\OMEN\Desktop\Final-Teqdimat\Backend\End_Project\End_Project\Areas\AdminArea\Views\Contact\Index.cshtml"
                                       Write(Html.Raw(contact.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 55 "C:\Users\OMEN\Desktop\Final-Teqdimat\Backend\End_Project\End_Project\Areas\AdminArea\Views\Contact\Index.cshtml"
                                       Write(Html.Raw(contact.Subject));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 57 "C:\Users\OMEN\Desktop\Final-Teqdimat\Backend\End_Project\End_Project\Areas\AdminArea\Views\Contact\Index.cshtml"
                                       Write(Html.Raw(contact.Message));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td style=\"text-align:center\">\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ab22190cb855a459049d1313a6fd2a2d8c0a21889544", async() => {
                WriteLiteral("<i class=\"fa-solid fa-circle-info\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 60 "C:\Users\OMEN\Desktop\Final-Teqdimat\Backend\End_Project\End_Project\Areas\AdminArea\Views\Contact\Index.cshtml"
                                                                     WriteLiteral(contact.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 63 "C:\Users\OMEN\Desktop\Final-Teqdimat\Backend\End_Project\End_Project\Areas\AdminArea\Views\Contact\Index.cshtml"

                                    count++;
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n    <script src=\"https://kit.fontawesome.com/706af225b1.js\"></script>\r\n");
            }
            );
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Contact>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591