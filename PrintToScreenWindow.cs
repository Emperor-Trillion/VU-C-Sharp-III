using System.Collections.Generic;
using System.Windows;

namespace finalProject
{
    public partial class PrintToScreenWindow : Window
    {
        private const int MaxValuesPerLine = 10; // Maximum number of values per line

        public PrintToScreenWindow()
        {
            InitializeComponent();
        }

        // Public property to append text
        public void AppendText(string text)
        {
            if (!string.IsNullOrEmpty(ReceivedPermutations.Text))
                ReceivedPermutations.Text += " ";

            ReceivedPermutations.Text += text;

            // Optionally, clear values if they exceed a certain number
            if (receivedValues.Count > MaxValuesPerLine)
                ClearValues();
        }

        // Method to clear all received values
        public void ClearValues()
        {
            receivedValues.Clear();
            UpdateDisplay();
        }

        // Private method to update the display of received values
        private void UpdateDisplay()
        {
            ReceivedPermutations.Text = string.Join(" ", receivedValues);
        }

        // Private list to store values received
        private List<string> receivedValues = new List<string>();

        // Event handler for the Proceed button click
        private void OnProceedClicked(object sender, RoutedEventArgs e)
        {
            DisplayResultWindow displayResultWindow = new DisplayResultWindow();
            // Use the 'threads' variable as needed for your logic
            // For example, you might pass it to another method or window
            displayResultWindow.Show();
            this.Close();
        }
    }
}
