Imports DevExpress.DataAccess.Native.Sql.ConnectionStrategies
Imports DevExpress.DataAccess.Sql
Imports DevExpress.DataAccess.UI.Wizard
Imports DevExpress.DataAccess.Wizard
Imports DevExpress.DataAccess.Wizard.Model
Imports DevExpress.DataAccess.Wizard.Presenters
Imports DevExpress.DataAccess.Wizard.Services
Imports DevExpress.DataAccess.Wizard.Views
Imports DevExpress.Entity.ProjectModel
Imports DevExpress.Snap.Services

Namespace CustomizeWizardExample
#Region "#DataSourceWizardCustomizationService"
    Public Class DataSourceWizardCustomizationService
        Implements IDataSourceWizardCustomizationService

        Public Sub CustomizeDataSourceWizard(ByVal tool As IWizardCustomization(Of DataSourceModel)) Implements IDataSourceWizardCustomizationService.CustomizeDataSourceWizard
            tool.WizardTitle = "Custom Data Source Wizard"

            ' Specify the first page for the Data Source Wizard.
            tool.StartPage = GetType(CustomChooseDataSourceNamePage)
            ' Register the modified "Enter the data source name" wizard page.
            tool.RegisterPage(Of CustomChooseDataSourceNamePage, CustomChooseDataSourceNamePage)()
            ' Register the modified "Select the data source type" wizard page.
            tool.RegisterPage(Of CustomChooseDataSourceTypePage, CustomChooseDataSourceTypePage)()

            ' Restrict the number of available data providers to three predefined items. 
            Dim providers As List(Of ProviderLookupItem) = CType(tool.Resolve(GetType(List(Of ProviderLookupItem))), List(Of ProviderLookupItem))
            providers.Clear()
            providers.Add(New ProviderLookupItem("MSSqlServer", "Microsoft SQL Server", New MsSqlServerStrategy()))
            providers.Add(New ProviderLookupItem("Access97", "Microsoft Access 97", New Access97Strategy()))
            providers.Add(New ProviderLookupItem("Access2007", "Microsoft Access 2007", New Access2007Strategy()))
        End Sub
    End Class
#End Region ' #DataSourceWizardCustomizationService

#Region "#CustomPages"
    Public Class CustomChooseDataSourceNamePage
        Inherits ChooseDataSourceNamePage(Of DataSourceModel)

        Public Sub New(ByVal view As IChooseDataSourceNamePageView, ByVal dataSourceNameCreator As IDataSourceNameCreationService)
            MyBase.New(view, dataSourceNameCreator)
        End Sub

        ' Override the GetNextPageType method to open the modified "Select the data source type" page when an end-user clicks "Next". 
        Public Overrides Function GetNextPageType() As Type
            Return GetType(CustomChooseDataSourceTypePage)
        End Function
    End Class

    Friend Class CustomChooseDataSourceTypePage
        Inherits ChooseDataSourceTypePage(Of DataSourceModel)

        Public Sub New(ByVal view As IChooseDataSourceTypePageView, ByVal context As IWizardRunnerContext, ByVal dataConnections As IEnumerable(Of SqlDataConnection), ByVal solutionTypesProvider As ISolutionTypesProvider, options As SqlWizardOptions)
            MyBase.New(view, context, dataConnections, solutionTypesProvider, options)
        End Sub

        Public Overrides Function GetNextPageType() As Type
            ' Skip the wizard page that enables usage of the existing connection to a database and directly move to the page that allows you to create a new connection. 
            If View.DataSourceType Is DataSourceType.Xpo Then
                Return GetType(ConnectionPropertiesPage(Of DataSourceModel))
            End If
            ' If the data source type is other than "Database", display the standard wizard page corresponding to the selected type.
            Return MyBase.GetNextPageType()
        End Function
    End Class
#End Region ' #CustomPages
End Namespace
