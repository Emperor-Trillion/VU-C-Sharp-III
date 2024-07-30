using System.Windows;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>

namespace finalProject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenCreatePasswordWindow(object sender, RoutedEventArgs e)
        {
            CreatePasswordWindow createPasswordWindow = new CreatePasswordWindow();
            createPasswordWindow.Show();
            this.Close();
        }
    }
}

