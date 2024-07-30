using System.Windows;

namespace finalProject
{
    public partial class SuccessWindow : Window
    {
        public SuccessWindow()
        {
            InitializeComponent();
        }

        private void OnReturnClicked(object sender, RoutedEventArgs e)
        {
            CreatePasswordWindow createPasswordWindow = new CreatePasswordWindow();
            // Navigate to another window if necessary
            createPasswordWindow.Show();
            this.Close();
        }
        private void OnApplyForceClicked(object sender, RoutedEventArgs e)
        {
             DecryptPasswordWindow decryptPasswordWindow = new DecryptPasswordWindow();
             decryptPasswordWindow.Show();
            // Navigate to another window if necessary
            this.Close();
        }
    }
}
