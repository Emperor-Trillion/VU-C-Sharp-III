using System;
using System.Windows;

namespace finalProject
{
    public partial class DecryptPasswordWindow : Window
    {
        public DecryptPasswordWindow()
        {
            InitializeComponent();
            CoresTextBlock.Text = ReadCoreUnits.DisplayNumberOfCores();
        }

        private void OnSpecifyThreadsChecked(object sender, RoutedEventArgs e)
        {
            bool isChecked = SpecifyThreadsCheckBox.IsChecked ?? false;
            ThreadsToUse.IsEnabled = isChecked;
        }

        private void OnBeginAttackClicked(object sender, RoutedEventArgs e)
        {
            int threads = 1; // Default to 1 if not specified

            if (SpecifyThreadsCheckBox.IsChecked == true)
            {
                if (int.TryParse(ThreadsToUse.Text, out int parsedThreads) && parsedThreads > 0)
                {
                    threads = parsedThreads;
                    PermutationGenerationMethod.BeginAttack(useMultithreading: true, maxThreads: threads);
                    this.Close();
                }
                else
                {
                    MessageDisplayWindow.ShowMessage("Please enter a valid number of threads.");
                    return;
                }
            }
            else
            {
                PermutationGenerationMethod.BeginAttack(useMultithreading: false, maxThreads: 1);
                this.Close();
            }
        }

        private void OnReturnClicked(object sender, RoutedEventArgs e)
        {
            CreatePasswordWindow createPasswordWindow = new CreatePasswordWindow();
            createPasswordWindow.Show();
            this.Close();
        }
    }
}
