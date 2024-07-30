using System;
using System.Windows;

namespace finalProject
{
    public class ReadCoreUnits
    {
        public static string DisplayNumberOfCores()
        {
            int numberOfCores = Environment.ProcessorCount;
            string CoresTextBlock = $"Number of CPU Cores: {numberOfCores}";
            return CoresTextBlock;
        }
    }
}
