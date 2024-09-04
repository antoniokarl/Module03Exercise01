using Microsoft.Maui.Controls;

namespace Module03Exercise01.View
{
    public partial class OfflinePage : ContentPage
    {
        public OfflinePage()
        {
            InitializeComponent();
        }

        private void OnCloseAppClicked(object sender, EventArgs e)
        {
            Application.Current.Quit(); // Close the application
        }
    }
}
