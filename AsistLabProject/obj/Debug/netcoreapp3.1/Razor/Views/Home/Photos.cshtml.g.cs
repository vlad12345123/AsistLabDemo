#pragma checksum "C:\Users\0XDA0\source\repos\AsistLabProject\AsistLabProject\Views\Home\Photos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ca607a07b6939943d4cf03f21eb6165b569229bb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Photos), @"mvc.1.0.view", @"/Views/Home/Photos.cshtml")]
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
#line 1 "C:\Users\0XDA0\source\repos\AsistLabProject\AsistLabProject\Views\_ViewImports.cshtml"
using AsistLabProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\0XDA0\source\repos\AsistLabProject\AsistLabProject\Views\_ViewImports.cshtml"
using AsistLabProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca607a07b6939943d4cf03f21eb6165b569229bb", @"/Views/Home/Photos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"001ef63eef2880784d917d021a747bfee1052504", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Photos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Photos>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<table id=""photosTable"">
    <thead>
        <tr>
            <th>id</th>
            <th>albumId</th>
            <th>thumbNailUrl</th>
            <th>title</th>
            <th>url</th>
        </tr>
    </thead>
</table>

<link href=""//cdn.datatables.net/1.10.24/css/jquery.dataTables.min.css"" />

");
            DefineSection("scripts", async() => {
                WriteLiteral(@"

    <script src=""//cdn.datatables.net/1.10.24/js/jquery.dataTables.min.js""></script>

    <script>
        $(document).ready(function () {
            $(""#photosTable"").DataTable(
                {
                    ajax: {
                        url: ""/Home/GetPhotos"",
                        type: ""GET"",
                        contentType: ""application/json"",
                        datatype: ""json"",
                        dataSrc: """",
                        //success: function (data) {
                        //    console.log(data);
                        //}
                    },
                    columns: [
                        { data: ""id"" },
                        { data: ""albumId"" },
                        { data: ""title"" },
                        { data: ""thumbnailUrl"" },
                        { data: ""url"" }

                    ],
                    error: function (error) {
                        alert(""Error = "" + error);
                    }
 ");
                WriteLiteral("               });\r\n        })\r\n    </script>\r\n\r\n");
            }
            );
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Photos>> Html { get; private set; }
    }
}
#pragma warning restore 1591
