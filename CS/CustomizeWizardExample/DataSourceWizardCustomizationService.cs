using DevExpress.DataAccess.Native.Sql.ConnectionStrategies;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.UI.Wizard;
using DevExpress.DataAccess.Wizard;
using DevExpress.DataAccess.Wizard.Model;
using DevExpress.DataAccess.Wizard.Presenters;
using DevExpress.DataAccess.Wizard.Services;
using DevExpress.DataAccess.Wizard.Views;
using DevExpress.Entity.ProjectModel;
using DevExpress.Snap.Services;
using System;
using System.Collections.Generic;

namespace CustomizeWizardExample {
    #region #DataSourceWizardCustomizationService
    public class DataSourceWizardCustomizationService : IDataSourceWizardCustomizationService {
        public void CustomizeDataSourceWizard(IWizardCustomization<DataSourceModel> tool) {
            tool.WizardTitle = "Custom Data Source Wizard";

            // Specify the first page for the Data Source Wizard.
            tool.StartPage = typeof(CustomChooseDataSourceNamePage);
            // Register the modified "Enter the data source name" wizard page.
            tool.RegisterPage<CustomChooseDataSourceNamePage, CustomChooseDataSourceNamePage>();
            // Register the modified "Select the data source type" wizard page.
            tool.RegisterPage<CustomChooseDataSourceTypePage, CustomChooseDataSourceTypePage>();

            // Restrict the number of available data providers to three predefined items. 
            List<ProviderLookupItem> providers = (List<ProviderLookupItem>)tool.Resolve(typeof (List<ProviderLookupItem>));
            providers.Clear();
            providers.Add(new ProviderLookupItem("MSSqlServer", "Microsoft SQL Server", new MsSqlServerStrategy()));
            providers.Add(new ProviderLookupItem("Access97", "Microsoft Access 97", new Access97Strategy()));
            providers.Add(new ProviderLookupItem("Access2007", "Microsoft Access 2007", new Access2007Strategy()));
        }
    }
    #endregion #DataSourceWizardCustomizationService

	#region #CustomPages
    public class CustomChooseDataSourceNamePage : ChooseDataSourceNamePage<DataSourceModel> 
    {
        public CustomChooseDataSourceNamePage(IChooseDataSourceNamePageView view, IDataSourceNameCreationService dataSourceNameCreator)
            : base(view, dataSourceNameCreator){ }

        // Override the GetNextPageType method to open the modified "Select the data source type" page when an end-user clicks "Next". 
        public override Type GetNextPageType()
        {
            return typeof(CustomChooseDataSourceTypePage);
        }
    }

    internal class CustomChooseDataSourceTypePage : ChooseDataSourceTypePage<DataSourceModel>
    {
        public CustomChooseDataSourceTypePage(IChooseDataSourceTypePageView view, IWizardRunnerContext context, IEnumerable<SqlDataConnection> dataConnections, ISolutionTypesProvider solutionTypesProvider)
            : base(view, context, dataConnections, solutionTypesProvider){ }

        public override Type GetNextPageType()
        {
            // Skip the wizard page that enables usage of the existing connection to a database and directly move to the page that allows you to create a new connection. 
            if (View.DataSourceType == DataSourceType.Xpo)
                return typeof(ConnectionPropertiesPage<DataSourceModel>);
            // If the data source type is other than "Database", display the standard wizard page corresponding to the selected type.
            return base.GetNextPageType();
        }
    }
	#endregion #CustomPages
}
