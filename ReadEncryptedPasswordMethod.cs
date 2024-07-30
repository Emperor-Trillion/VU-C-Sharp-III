using System.IO;

namespace finalProject
{
    public class ReadEncryptedPasswordMethod
    {
        public static string[]? ReadEncryptedPassword(string filePath)
        {

            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string fullPath = Path.Combine(currentDirectory, filePath);

            try
            {
                // Read the entire file into an array of strings
                string[] lines = new string[2];
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string passwords = reader.ReadLine() ?? "";
                        lines = passwords.Split(",");
                    }
                }
                // Check if there is any line in the file
                if (lines.Length > 0)
                {
                    // Return the first line from the file
                    return lines;
                }
                else
                {
                    MessageDisplayWindow.ShowMessage("The file is empty.");
                    return Array.Empty<string>();
                }
            }
            catch (Exception e)
            {
                MessageDisplayWindow.ShowMessage($"An unexpected exception occurred: {e.Message}");
                return null;
            }
        }
    }
}
