using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Extensions
{
    /// <summary>
    /// return object into string using dynamicc
    /// </summary>
    public static class StringConverterExtension
    {
        /// <summary>
        /// return object into string using dynamic object
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToSafeString(dynamic value)
        {
            string result;
            try
            {
                var convertible = value as IConvertible;
                result = (value != null) ? (convertible == null) ? Convert.ToString(value) : Convert.ChangeType(value, typeof(string)) : String.Empty;
            }
            catch (Exception)
            {
                result = string.Empty;
            }

            return result;
        }

        /// <summary>
        /// return object into string using dynamic object with nullable result
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToNullableSafeString(dynamic value)
        {
            string result;
            try
            {
                var convertible = value as IConvertible;
                result = (value != null) ? (convertible == null) ? Convert.ToString(value) : Convert.ChangeType(value, typeof(string)) : default;
            }
            catch (Exception)
            {
                result = default;
            }

            return result;
        }

        /// <summary>
        /// Convert string into its boolean equivalent
        /// </summary>
        /// <param name="value"></param>
        /// <returns>boolean equivalent</returns>
        /// <remarks>
        ///     <exception cref="ArgumentException">
        ///         thrown in the event no boolean equivalent found or and empty or whitespace 
        ///         string is passed
        ///     </exception>
        /// </remarks>
        public static bool ToBoolean(this string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("value is not accepted");
            }

            string val = value.ToLower().Trim();
            switch (val)
            {
                case "false":
                    return false;
                case "f":
                    return false;
                case "true":
                    return true;
                case "t":
                    return true;
                case "yes":
                    return true;
                case "no":
                    return false;
                case "y":
                    return true;
                case "n":
                    return false;
                case "ya":
                    return true;
                case "tidak":
                    return false;
                default:
                    throw new ArgumentException("Invalid boolean argument");
            }
        }

        /// <summary>
        /// Convert string to datetime
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string dateString)
        {
            DateTime resultDate;
            if (DateTime.TryParse(dateString, out resultDate))
                return resultDate;

            return default; 
        }

        /// <summary>
        /// convert 
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns></returns>
        public static DateTime? ToNullableDateTime(this string dateString)
        {
            if (string.IsNullOrEmpty((dateString ?? "").Trim()))
                return null;

            DateTime resultDate;
            if (DateTime.TryParse(dateString, out resultDate))
                return resultDate;

            return null;
        }

        /// <summary>
        /// convert string to int32 for default value to 0
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ToInt32(this string value, int defaultValue = 0)
        {
            int parsedInt;
            if (int.TryParse(value, out parsedInt))
                return parsedInt;

            return defaultValue;
        }

        /// <summary>
        /// convert string to Int64 with default value 0
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static long ToInt64(this string value, long defaultValue = 0)
        {
            long parsedInt64;
            if (Int64.TryParse(value, out parsedInt64))
                return parsedInt64;

            return defaultValue;
        }
        
        /// <summary>
        /// convert string to Int32 with nullable options
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int? ToNullableInt32(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            int parsedInt;
            if (int.TryParse(value, out parsedInt))
                return parsedInt;

            return null;
        }

        /// <summary>
        /// convert string to Int64 with nullable options
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long? ToNullableInt64(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            long parsedInt64;
            if (Int64.TryParse(value, out parsedInt64))
                return parsedInt64;

            return null;
        }

        /// <summary>
        /// Replace text ignoring with option comparison 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <param name="stringComparison"></param>
        /// <returns></returns>
        public static string Replace (this string text, string oldValue, string newValue, StringComparison stringComparison)
        {
            if (string.IsNullOrEmpty(text))
                return default;
            if (oldValue == String.Empty)
                return text;
            if (oldValue == null)
                throw new ArgumentException("Value before comprehend is not initialized");
            if (newValue == null)
                throw new ArgumentException("Value after comprehend is not initialized");

            const int indexNotFound = -1;
            int startIndex = 0, index = 0;

            while((index = text.IndexOf(oldValue, startIndex, stringComparison)) != indexNotFound)
            {
                text = text.Substring(0, index) + newValue + text.Substring(index + oldValue.Length);
                startIndex = index + newValue.Length;
            }

            return text;
        }
    }
}
