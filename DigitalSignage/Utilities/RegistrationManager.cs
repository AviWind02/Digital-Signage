﻿using Microsoft.Win32;
using System;


namespace DigitalSignage.Utilities
{
    internal class RegistrationManager
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
                return;
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

        public string ReadRegistryValueString(string keyName)
        {
            Console.WriteLine($"Attempting to read registry value for '{keyName}'...");
            string defaultValue = null;
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(BaseKeyPath))
                {
                    if (key != null)
                    {
                        object value = key.GetValue(keyName);
                        if (value != null)
                        {
                            Console.WriteLine($"Successfully read registry value '{keyName}': {value.ToString()}");
                            return value.ToString();
                        }
                        else
                        {
                            Console.WriteLine($"Registry value '{keyName}' not found. Using default value.");
                        }
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
        public void WriteRegistryValueAsString(string keyName, string value)
        {
            Console.WriteLine($"Attempting to write '{value}' to registry value '{keyName}'...");

            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(BaseKeyPath))
                {
                    if (key != null)
                    {
                        key.SetValue(keyName, value, RegistryValueKind.String);
                        Console.WriteLine($"Registry value '{keyName}' set to '{value}'.");
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
