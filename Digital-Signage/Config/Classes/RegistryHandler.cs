using Microsoft.Win32;
using System;

namespace Digital_Signage.Config.Classes
{
    internal class RegistryHandler
    {
        private const string BaseKeyPath = @"SOFTWARE\Digital-Signage";

        public void CreateMainDirectory()
        {
            Console.WriteLine("Attempting to create main registry directory...");

            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(BaseKeyPath))
                {
                    if (key == null)
                    {
                        Console.WriteLine("Failed to create registry key.");
                    }
                    else
                    {
                        Console.WriteLine($"Registry key '{BaseKeyPath}' created successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating registry key: {ex.Message}");
            }
        }

        public int ReadRegistryValue(string keyName)
        {
            Console.WriteLine($"Attempting to read registry value for '{keyName}'...");
            int defaultValue = 0;
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(BaseKeyPath))
                {
                    if (key != null)
                    {
                        object value = key.GetValue(keyName);
                        Console.WriteLine($"Successfully read registry value '{keyName}': {Convert.ToInt32(value)}");
                        return Convert.ToInt32(value);
                    }
                    else
                    {
                        Console.WriteLine($"Registry key '{BaseKeyPath}' not found for '{keyName}'. Using default value.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading registry value '{keyName}': {ex.Message}");
            }

            Console.WriteLine($"Returning default value for '{keyName}': {defaultValue}");
            return defaultValue;
        }

        public void WriteRegistryValue(string keyName, int value)
        {
            Console.WriteLine($"Attempting to write '{value}' to registry value '{keyName}'...");

            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(BaseKeyPath))
                {
                    if (key != null)
                    {
                        key.SetValue(keyName, value, RegistryValueKind.DWord);
                        Console.WriteLine($"Registry value '{keyName}' set to {value}.");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to create or open registry key '{BaseKeyPath}' for writing.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing registry value '{keyName}': {ex.Message}");
            }
        }
    }
}
