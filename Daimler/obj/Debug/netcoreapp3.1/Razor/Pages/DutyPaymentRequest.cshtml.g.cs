#pragma checksum "E:\Old Source\Daimler\Daimler\Pages\DutyPaymentRequest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a3e9d0f60504f42ca8e5ab92a041f838e244959e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Daimler.Pages.Pages_DutyPaymentRequest), @"mvc.1.0.razor-page", @"/Pages/DutyPaymentRequest.cshtml")]
namespace Daimler.Pages
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
#line 1 "E:\Old Source\Daimler\Daimler\Pages\_ViewImports.cshtml"
using Daimler;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3e9d0f60504f42ca8e5ab92a041f838e244959e", @"/Pages/DutyPaymentRequest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"caa2b7212196503e721ebb9231785fb8358ade58", @"/Pages/_ViewImports.cshtml")]
    public class Pages_DutyPaymentRequest : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-top:10px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "file", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Browse File", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "E:\Old Source\Daimler\Daimler\Pages\DutyPaymentRequest.cshtml"
  
    ViewData["Title"] = "Duty Payment Request";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <script type=""text/javascript"">
    debugger;
    window.onload = function () {
        removeClass()
    }
    function removeClass() {
        document.getElementById(""Dashboard"").classList.remove(""active"");
        document.getElementById(""duty_payment_request"").classList.add(""active"");
        document.getElementById(""uploadisc"").classList.remove(""active"");
        document.getElementById(""uploadidt"").classList.remove(""active"");
        document.getElementById(""archive_records"").classList.remove(""active"");
    }

    function deletedutypayment (id)
    {
        if (confirm(""Are you sure you want to delete ...?"")) {
            $.ajax({
                            type: 'GET',
                            datatype: ""json"",
                            traditional: true,
            data: { 'id': JSON.stringify(id) },
            url: '");
#nullable restore
#line 29 "E:\Old Source\Daimler\Daimler\Pages\DutyPaymentRequest.cshtml"
             Write(Url.Page("DutyPaymentRequest", "detele", null));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            success: function (result) {
                alert(""Delete  Duty Payment Request !"");
                location.reload();
                oTable = $('#manageusers').DataTable();
                oTable.draw(); 
            },
            error: function (errormessage) {
                alert(""Something Went Wrong!"");
            }
        });
        }
        else {
            return false;
        }


    }
    </script>
<style>


    .btn_cols {
        background-color: #28a745;
        border-color: #28a745;
    }
</style>
<link");
            BeginWriteAttribute("href", " href=\"", 1609, "\"", 1653, 1);
#nullable restore
#line 56 "E:\Old Source\Daimler\Daimler\Pages\DutyPaymentRequest.cshtml"
WriteAttributeValue("", 1616, Url.Content("~/Content/Gridmvc.css"), 1616, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" rel=\"stylesheet\" />\r\n<link");
            BeginWriteAttribute("href", " href=\"", 1681, "\"", 1731, 1);
#nullable restore
#line 57 "E:\Old Source\Daimler\Daimler\Pages\DutyPaymentRequest.cshtml"
WriteAttributeValue("", 1688, Url.Content("~/Content/bootstrap.min.css"), 1688, 43, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" rel=\"stylesheet\" />\r\n<script");
            BeginWriteAttribute("src", " src=\"", 1761, "\"", 1812, 1);
#nullable restore
#line 58 "E:\Old Source\Daimler\Daimler\Pages\DutyPaymentRequest.cshtml"
WriteAttributeValue("", 1767, Url.Content("~/Scripts/jquery-1.9.1.min.js"), 1767, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></script>\r\n<script");
            BeginWriteAttribute("src", " src=\"", 1832, "\"", 1878, 1);
#nullable restore
#line 59 "E:\Old Source\Daimler\Daimler\Pages\DutyPaymentRequest.cshtml"
WriteAttributeValue("", 1838, Url.Content("~/Scripts/gridmvc.min.js"), 1838, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"></script>
<div class=""page-container "">
    <!-- START PAGE CONTENT WRAPPER -->
    <div class=""page-content-wrapper "">
        <!-- START PAGE CONTENT -->
        <div class=""content sm-gutter"">
            <!-- START BREADCRUMBS -->
            <div class=""bg-white"">
                <div class=""container"">
                    <ol class=""breadcrumb breadcrumb-alt"">
                        <li class=""breadcrumb-item""><a href=""index.html"">Home</a></li>
                        <li class=""breadcrumb-item active"">Duty Payment Request</li>
                    </ol>
                </div>
            </div>
            <!-- END BREADCRUMBS -->
            <!-- START CONTAINER FLUID -->

            <div class=""container sm-padding-10 p-t-20 p-l-0 p-r-0 customdashboard"">

                <div class=""row p-l-20"">
                    <div class=""col-lg-12 sm-m-t-10 d-flex"">
                        <!-- START WIDGET widget_pendingComments.tpl-->
                        <div class=""widget-11-2 ca");
            WriteLiteral(@"rd no-border card-condensed no-margin widget-loader-circle d-flex flex-column align-self-stretch"">
                            <div class=""card-header top-right"">
                                <div class=""card-controls"">
                                    <ul>
                                        <li>
                                            <a data-toggle=""refresh"" class=""portlet-refresh text-black"" href=""#"">
                                                <i class=""portlet-icon portlet-icon-refresh""></i>
                                            </a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a3e9d0f60504f42ca8e5ab92a041f838e244959e10509", async() => {
                WriteLiteral("\r\n                                <div class=\"auto-overflows \" style=\"margin-top:10px;margin-left:10px;\">\r\n                                    <div class=\"row\">\r\n\r\n");
                WriteLiteral(@"                                        <div class=""drag-area pb-4"">
                                            <div class=""icon""><i class=""fa fa-cloud-upload""></i></div>
                                            <header>Drag & Drop to Upload Duty Payment Request</header>
                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a3e9d0f60504f42ca8e5ab92a041f838e244959e11307", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 128 "E:\Old Source\Daimler\Daimler\Pages\DutyPaymentRequest.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Upload);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                        </div>\r\n                                        <div class=\"col-lg-4 text-center\">\r\n                                            <img src=\"assets/img/2941039.png\" class=\"uploadicon\" type=\"button\"");
                BeginWriteAttribute("alt", " alt=\"", 6344, "\"", 6350, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                            <input type=\"submit\" />\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

                        </div>

                    </div>
                    <!-- END WIDGET -->
                </div>
                <table class=""table table-condensed table-hover"" style=""width: 100%"" id=""manageusers"">
                    <tr>
                        <th style=""width: 5%;"">#</th>
                        <th style=""width: 15%;"">File Name</th>
                        <th style=""width: 11%;"">Document</th>
                        <th style=""width: 20%;"">Uploaded (Date/Time)</th>
                        <th style=""width: 15%;"">Uploaded by</th>
                        <th style=""width: 15%;"">DPR No</th>
                        <th style=""width: 11%;"" class=""text-center"">BOE Records</th>
                        <th style=""width: 13%;"">Status</th>
");
            WriteLiteral("                    </tr>\r\n\r\n");
#nullable restore
#line 164 "E:\Old Source\Daimler\Daimler\Pages\DutyPaymentRequest.cshtml"
                     foreach (var item in Model.dutyPaymentRequestHeaders)
                    {
                        string selectedRow = "";
                        //if (item.Id == Model.dutyPaymentRequestHeader.Id)
                        //{
                        //    selectedRow = "table-success";
                        //}

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr");
            BeginWriteAttribute("class", " class=\"", 8066, "\"", 8086, 1);
#nullable restore
#line 171 "E:\Old Source\Daimler\Daimler\Pages\DutyPaymentRequest.cshtml"
WriteAttributeValue("", 8074, selectedRow, 8074, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <td>\r\n                        ");
#nullable restore
#line 173 "E:\Old Source\Daimler\Daimler\Pages\DutyPaymentRequest.cshtml"
                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 176 "E:\Old Source\Daimler\Daimler\Pages\DutyPaymentRequest.cshtml"
                   Write(item.FileName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"b-r b-dashed b-grey w-25\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 8355, "\"", 8376, 1);
#nullable restore
#line 179 "E:\Old Source\Daimler\Daimler\Pages\DutyPaymentRequest.cshtml"
WriteAttributeValue("", 8362, item.Download, 8362, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\"><img class=\"img-responsive\" src=\"assets/img/xlsx.png\" width=\"40\" height=\"30\"></a>\r\n                    </td>\r\n\r\n\r\n                    <td class=\"b-r b-dashed b-grey w-25\">\r\n                        ");
#nullable restore
#line 184 "E:\Old Source\Daimler\Daimler\Pages\DutyPaymentRequest.cshtml"
                   Write(item.UploadedDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"b-r b-dashed b-grey w-25\">\r\n                        ");
#nullable restore
#line 187 "E:\Old Source\Daimler\Daimler\Pages\DutyPaymentRequest.cshtml"
                   Write(item.UploadedBy);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"b-r b-dashed b-grey w-25\">\r\n                        ");
#nullable restore
#line 190 "E:\Old Source\Daimler\Daimler\Pages\DutyPaymentRequest.cshtml"
                   Write(item.Dprno);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"b-r b-dashed b-grey w-25\">\r\n                        ");
#nullable restore
#line 193 "E:\Old Source\Daimler\Daimler\Pages\DutyPaymentRequest.cshtml"
                   Write(item.DocumentReference);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 195 "E:\Old Source\Daimler\Daimler\Pages\DutyPaymentRequest.cshtml"
                     if (@item.Status == "Accepted  ")
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td class=\"b-r b-dashed b-grey w-25\">\r\n                            <span class=\"text-complete\">");
#nullable restore
#line 198 "E:\Old Source\Daimler\Daimler\Pages\DutyPaymentRequest.cshtml"
                                                   Write(item.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>&nbsp;&nbsp;\r\n                            <a href=\"javascript:void(0);\"");
            BeginWriteAttribute("onclick", " onclick=\"", 9312, "\"", 9349, 3);
            WriteAttributeValue("", 9322, "deletedutypayment(", 9322, 18, true);
#nullable restore
#line 199 "E:\Old Source\Daimler\Daimler\Pages\DutyPaymentRequest.cshtml"
WriteAttributeValue("", 9340, item.Id, 9340, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 9348, ")", 9348, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"text-danger\"><span class=\"fa fa-trash\"></span></a>\r\n                        </td>\r\n");
#nullable restore
#line 201 "E:\Old Source\Daimler\Daimler\Pages\DutyPaymentRequest.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 202 "E:\Old Source\Daimler\Daimler\Pages\DutyPaymentRequest.cshtml"
                     if (@item.Status == "Rejected  ")
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td class=\"b-r b-dashed b-grey w-25\">\r\n                            <span class=\"text-danger\">");
#nullable restore
#line 205 "E:\Old Source\Daimler\Daimler\Pages\DutyPaymentRequest.cshtml"
                                                 Write(item.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </td>\r\n");
#nullable restore
#line 207 "E:\Old Source\Daimler\Daimler\Pages\DutyPaymentRequest.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </tr>\r\n");
#nullable restore
#line 210 "E:\Old Source\Daimler\Daimler\Pages\DutyPaymentRequest.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </table>
                <select name=""filelist""  style=""visibility:hidden"">  
                    </select>
            </div>

            
            <!-- START ROW -->
            <!-- START ROW -->
        </div>
        <!-- END CONTAINER FLUID -->
    </div>
    <br>
    <br>
    <br>
    <!-- END PAGE CONTENT -->
    <!-- START COPYRIGHT -->
    <!-- START CONTAINER FLUID -->
    <!-- START CONTAINER FLUID -->
    <div class="" container   container-fixed-lg footer"">
        <div class=""copyright sm-text-center"">
            <p class=""small no-margin pull-left sm-pull-reset"">
                <span class=""hint-text"">Copyright Reserved © 2020-2025. </span>

            </p>
            <p class=""small no-margin pull-right sm-pull-reset"">
                Developed by <span class=""hint-text"">Zealoit Technologies</span>
            </p>
            <div class=""clearfix""></div>
        </div>
    </div>
    <!-- END COPYRIGHT -->
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Daimler.Pages.DutyPaymentRequest> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Daimler.Pages.DutyPaymentRequest> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Daimler.Pages.DutyPaymentRequest>)PageContext?.ViewData;
        public Daimler.Pages.DutyPaymentRequest Model => ViewData.Model;
    }
}
#pragma warning restore 1591