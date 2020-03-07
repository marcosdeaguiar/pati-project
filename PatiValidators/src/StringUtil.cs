using System;

namespace Pati.Validators
{
    /// <summary>
    /// Class with string util methods to help on the validation.
    /// </summary>
    public class StringUtil
    {
        /// <summary>
        /// Checks whether the string is only composed of numbers.
        /// </summary>
        /// <param name="str">String to be checked.</param>
        /// <returns>Returns true if string has only numbers, false otherwise.</returns>
        public static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Converts a string composed of numbers to an array of int.
        /// </summary>
        /// <param name="str">String to be converted.</param>
        /// <returns>Return array of int with the numbers.</returns>
        public static int[] ToIntArray(string str)
        {
            int[] intArray = new int[11];

            for (int i = 0; i < 11; i++)
            {
                intArray[i] = (int)Char.GetNumericValue(str[i]);
            }

            return intArray;
        }
    }
}
