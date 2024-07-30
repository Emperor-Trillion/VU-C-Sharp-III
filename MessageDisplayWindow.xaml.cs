using System.Windows;

namespace finalProject
{
    public partial class MessageDisplayWindow : Window
    {
        public MessageDisplayWindow()
        {
            InitializeComponent();
        }

        // Static method to display message
        public static void ShowMessage(string message)
        {
            // Create an instance of MainWindow
            MessageDisplayWindow mainWindow = new MessageDisplayWindow();

            // Set the message text
            mainWindow.MessageTextBlock.Text = message;

            // Show the window
            mainWindow.ShowDialog();
        }
    }
}