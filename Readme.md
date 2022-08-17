<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128608613/18.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T307510)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# How to customize the Data Source Wizard

> **Note**
>
> As you may already know, the [WinForms Snap control](https://docs.devexpress.com/WindowsForms/11373/controls-and-libraries/snap) and [Snap Report API](https://docs.devexpress.com/OfficeFileAPI/15188/snap-report-api) are now in maintenance support mode. No new features or capabilities are incorporated into these products. We recommend that you use [DevExpress Reporting](https://docs.devexpress.com/XtraReports/2162/reporting) tool to generate, edit, print, and export your business reports/documents.

<p>This example demonstrates the use of the service which implements the <strong>DevExpress.Snap.Services.IDataSourceWizardCustomizationService</strong> interface and enables customization of the <a href="https://documentation.devexpress.com/#WindowsForms/CustomDocument15603">Data Source Wizard</a>.</p>
<p>In particular, this example shows how to skip the default wizard page, on which end-users can select an existing data connection and move directly to the custom page, which allows end-users to create a new connection using a restricted number of available data providers.<br /><img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-customize-the-data-source-wizard-t307510/18.1.3+/media/33e09b3b-878b-11e5-80bf-00155d62480c.png"></p>
<p>For implementation details, refer to the <a href="https://documentation.devexpress.com/#WindowsForms/CustomDocument114899">How to: Customize the Data Source Wizard</a> help topic.</p>

<br/>


