using System.IO;

namespace finalProject
{
    public class SaveEncryptedPasswordMethod
    {
        public static void SaveEncryptedPassword(string password, string plainText)
        {
            string textToSave = $"{password},{plainText}";

            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativeFilePath = Path.Combine(currentDirectory, "../../.././password.txt");
            try
            {
                File.WriteAllText(relativeFilePath, textToSave);

                MessageDisplayWindow.ShowMessage($"Password saved successfully.");
            }
            catch (IOException e)
            {
                MessageDisplayWindow.ShowMessage($"An IO exception occurred: {e.Message}");
            }
            catch (Exception e)
            {
                MessageDisplayWindow.ShowMessage($"An unexpected exception occurred: {e.Message}");
            }
        }
    }
}
