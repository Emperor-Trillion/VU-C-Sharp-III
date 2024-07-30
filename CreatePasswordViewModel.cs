using System;
using System.Windows;

namespace finalProject
{

    public class CreatePasswordViewModel
    {
        static public void CreatePassword(string password)
        {
            string encryptedPassword = EncryptionMethod.EncryptPassword(password);
            SaveEncryptedPasswordMethod.SaveEncryptedPassword(encryptedPassword, password);
        }
    }
}