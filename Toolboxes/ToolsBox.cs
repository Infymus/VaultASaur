/*
 * Author: Infymus
 * Description: VaultASaur
 * Copyright (c) 2025, Infymus. All rights reserved.
 * Website: https://github.com/Infymus/vaultasaur
*/

using System.Text;
using VaultASaur3.Config;
using System.Reflection;

namespace VaultASaur3.ToolsBox
{
   public static class ToolBox
   {

      // random defined 
      private static Random rnd = new Random();

      public static string ProperCase(string input, bool trim = true)
      {
         if (string.IsNullOrEmpty(input))
            return input;

         if (trim)
            input = input.Trim();

         input = input.ToLower();

         var result = new StringBuilder(input.Length);
         bool cap = true;
         char[] trigChars = { '"', '\'', '.', ',', '-', '_', '\\', '/', ' ', '(', ':',
                             '1','2','3','4','5','6','7','8','9','0' };

         for (int i = 0; i < input.Length; i++)
         {
            char c = input[i];

            if (cap && char.IsLetter(c))
               c = char.ToUpper(c);

            result.Append(c);

            // Look ahead for 's pattern (like it's or John's)
            if (c == '\'' && i < input.Length - 1 && input[i + 1] == 's')
            {
               cap = false;
            }
            else
            {
               cap = Array.IndexOf(trigChars, c) >= 0;
            }
         }

         return result.ToString();
      }

      public static string GetEnumDescription(Enum value)
      {
         FieldInfo field = value.GetType().GetField(value.ToString());

         if (field != null)
         {
            System.ComponentModel.DescriptionAttribute[] attributes =
                (System.ComponentModel.DescriptionAttribute[])field.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
               return attributes[0].Description;
            }
         }

         return value.ToString();  // Return the enum name if no description is found
      }

      public static bool ConvertEnumToBool<T>(T enumValue) where T : Enum
      {
         // Check if the enum value represents True or False
         if (Enum.IsDefined(typeof(T), enumValue))
         {
            // Return true if the value is True, false otherwise
            return enumValue.ToString() == "True";
         }
         else return false;
      }

      public static int ConvertEnumToInt<T>(T enumValue) where T : Enum
      {
         if (Enum.IsDefined(typeof(T), enumValue))
         {
            return Convert.ToInt32(enumValue);
         }
         else
         {
            throw new ArgumentException("Invalid enum value.");
         }
      }

      public static string GetEnumName(Enum value)
      {
         return value.ToString();
      }


      public static string GetBuildInfoAsString()
      {
         // Get the current assembly
         Assembly assembly = Assembly.GetExecutingAssembly();

         // Get version information
         Version version = assembly.GetName().Version;

         // Extract major and minor version only
         string majorMinorVersion = $"{version.Major}.{version.Minor}";

         return majorMinorVersion;
      }

      public static void WindowSizePosition(Form inForm, string inSetting, int inDefaultWidth, int inDefaultHeight)
      {
         inForm.Width = AppConfig.ReadInt("FormWidth", inDefaultWidth);
         inForm.Height = AppConfig.ReadInt("FormHeight", inDefaultHeight);
         inForm.Left = AppConfig.ReadInt("FormLeft", 0);
         inForm.Top = AppConfig.ReadInt("FormTop", 0);
      }

      public static string GetRandomPassword(bool usePunct, int pwLen)
      {
         const string LowercaseChars = "abcdefghijklmnopqrstuvwxyz";
         const string UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
         const string NumericChars = "0123456789";
         const string PunctuationChars = @"!@#$%^&*()_-+=[]{}\|:;?/>.<,`~";

         string charSet = LowercaseChars + UppercaseChars + NumericChars;

         if (usePunct)
         {
            charSet += PunctuationChars;
         }

         if (string.IsNullOrEmpty(charSet) || pwLen <= 0)
         {
            return string.Empty;
         }

         var password = new char[pwLen];
         int charSetLength = charSet.Length;

         for (int i = 0; i < pwLen; i++)
         {
            int randomIndex = rnd.Next(charSetLength);
            password[i] = charSet[randomIndex];
         }
         return new string(password.OrderBy(c => rnd.Next()).ToArray());
      }

   }
}
