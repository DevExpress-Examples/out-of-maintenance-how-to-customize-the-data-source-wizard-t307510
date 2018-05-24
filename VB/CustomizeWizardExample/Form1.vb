Imports DevExpress.Snap.Services

Namespace CustomizeWizardExample
    Partial Public Class Form1
        Inherits DevExpress.XtraBars.Ribbon.RibbonForm

        Public Sub New()
            InitializeComponent()
            snapControl.Text = "Invoke the customized Data Source Wizard by clicking the Add New Data Source button on the File tab."

'            #Region "#RegisterService"
            ' Register the service for the Data Source Wizard customization.   
            snapControl.AddService(GetType(IDataSourceWizardCustomizationService), New DataSourceWizardCustomizationService())
'            #End Region ' #RegisterService
        End Sub
    End Class
End Namespace
