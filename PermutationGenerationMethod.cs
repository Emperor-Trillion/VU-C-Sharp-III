using System;
using System.Collections.Generic;
using System.Windows;
using System.Threading.Tasks;
using System.Diagnostics;

namespace finalProject
{
    public class PermutationGenerationMethod
    {
        public static double executionTime;
        public static List<string> secureKeys = new List<string>();

        public static void GeneratePermutations(char[] characters, int n, Action<string> permutationHandler, string[] encryptedText, bool useMultithreading = false, int? maxThreads = null)
        {
            if (useMultithreading)
            {
                int maxDegreeOfParallelism = maxThreads ?? Environment.ProcessorCount - 1;

                // Ensure maxDegreeOfParallelism is at least 1
                maxDegreeOfParallelism = Math.Max(maxDegreeOfParallelism, 1);

                // Parallelize the generation of permutations
                Parallel.For(1, n + 1, new ParallelOptions { MaxDegreeOfParallelism = maxDegreeOfParallelism }, length =>
                {
                    GeneratePermutationsRecursive(characters, "", length, permutationHandler, encryptedText);
                });
            }
            else
            {
                // Single-threaded execution
                for (int length = 1; length <= n; length++)
                {
                    GeneratePermutationsRecursive(characters, "", length, permutationHandler, encryptedText);
                }
            }
        }

        private static bool GeneratePermutationsRecursive(char[] characters, string prefix, int remainingLength, Action<string> permutationHandler, string[] encryptedText)
        {
            if (remainingLength == 0)
            {
                // Handle the permutation immediately
                string decryptedResult = DecryptionMethod.TryDecryptPassword(encryptedText[0], prefix);

                // Check the condition
                if (decryptedResult.Contains(encryptedText[1]))
                {
                    TimeSpan timetaken = TimerMethod.Stop();
                    executionTime = timetaken.TotalMilliseconds;
                    secureKeys.Add(prefix);
                    secureKeys.Add(decryptedResult);
                    return true; // Break the recursion
                }

                permutationHandler(prefix);
                return false;
            }

            for (int i = 0; i < characters.Length; i++)
            {
                string newPrefix = prefix + characters[i];
                bool conditionMet = GeneratePermutationsRecursive(characters, newPrefix, remainingLength - 1, permutationHandler, encryptedText);

                if (conditionMet)
                    return true; // Break the recursion
            }

            return false;
        }

        public static void GenerateDefaultPermutations(Action<string> permutationHandler, string[] encryptedText, bool useMultithreading = false, int? maxThreads = null)
        {
            char[] alphabetAndNumbers = "abcdef".ToCharArray();
            int n = 5;

            // If multithreading is enabled, use maxThreads as provided
            // If not specified, use Environment.ProcessorCount - 1
            GeneratePermutations(alphabetAndNumbers, n, permutationHandler, encryptedText, useMultithreading, maxThreads);
        }

        public static void BeginAttack(bool useMultithreading = false, int? maxThreads = null)
        {
            string filePath = "password.txt";
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string[] encryptedText = ReadEncryptedPasswordMethod.ReadEncryptedPassword(filePath);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            // Create PrintToScreenWindow instance once
            PrintToScreenWindow printWindow = new PrintToScreenWindow();
            printWindow.Show();

            GenerateDefaultPermutations(permutation =>
#pragma warning disable CS8604 // Possible null reference argument.
            {
                TimerMethod.Start();
                // Update UI thread correctly
                Application.Current.Dispatcher.Invoke(() =>
                {
                    // Append the permutation to the existing text
                    printWindow.AppendText(permutation);
                });

            }, encryptedText, useMultithreading, maxThreads);
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
