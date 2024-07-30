using System.Windows;

namespace finalProject
{
    public partial class DisplayResultWindow : Window
    {
        public DisplayResultWindow()
        {
            InitializeComponent();
            SaltUsed.Text = PermutationGenerationMethod.secureKeys[0];
            DecryptedPassword.Text = PermutationGenerationMethod.secureKeys[1];
            TimeTaken.Text = PermutationGenerationMethod.executionTime.ToString() + " Milliseconds";
            PermutationGenerationMethod.secureKeys.Clear();
        }

        private void OnReturnClicked(object sender, RoutedEventArgs e)
        {
            CreatePasswordWindow createPasswordWindow = new CreatePasswordWindow();
            // Navigate to another window if necessary
            createPasswordWindow.Show();
            this.Close();
        }
    }
}
