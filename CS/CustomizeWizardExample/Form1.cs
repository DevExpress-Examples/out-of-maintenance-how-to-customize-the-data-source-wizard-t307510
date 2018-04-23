using DevExpress.Snap.Services;

namespace CustomizeWizardExample
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1() {
            InitializeComponent();
            snapControl.Text = "Invoke the customized Data Source Wizard by clicking the Add New Data Source button on the File tab.";

            #region #RegisterService
            // Register the service for the Data Source Wizard customization.   
            snapControl.AddService(typeof(IDataSourceWizardCustomizationService), new DataSourceWizardCustomizationService());
            #endregion #RegisterService
        }
    }
}
