using System;
using System.Windows;

namespace finalProject
{
    public partial class CreatePasswordWindow : Window
    {
        public CreatePasswordWindow()
        {
            InitializeComponent();
        }

        private void OnCreatePasswordClicked(object sender, RoutedEventArgs e)
        {
            string password = PasswordTextBox.Text.Trim(); // Trim any leading or trailing whitespace

            // Validate password
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Password cannot be empty or just whitespace.", "Invalid Password",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (password[0] == ' ')
            {
                MessageBox.Show("Password cannot start with a space.", "Invalid Password",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // If validation passes, proceed to create password
            CreatePasswordViewModel.CreatePassword(password);

            SuccessWindow successWindow = new SuccessWindow();
            successWindow.Show();
            this.Close();
        }

        private void OnBreakExistingPasswordClicked(object sender, RoutedEventArgs e)
        {
            DecryptPasswordWindow decryptPasswordWindow = new DecryptPasswordWindow();
            decryptPasswordWindow.Show();
            // Navigate to another window if necessary
            this.Close();
        }
    }
}
