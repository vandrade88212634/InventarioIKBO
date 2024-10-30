using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using static Common.Utils.Enums.Enums;

namespace Common.Utils.Utils
{
    [ExcludeFromCodeCoverage]
    public static class ExtendedMethods
    {
        /// <summary>
        /// return nullable date with format yyyy-MM-dd
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToStringDateFormatted(this DateTime? date)
        {
            string result = string.Empty;
            if (date != null)
                result = Convert.ToDateTime(date).ToString("yyyy-MM-dd");
            return result;
        }

        /// <summary>
        /// return date with format yyyy-MM-dd
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToStringDateFormatted(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// return nullable date with format yyyy-MM-dd
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToShortStringDateFormatted(this DateTime? date)
        {
            string result = string.Empty;
            if (date != null)
                result = Convert.ToDateTime(date).ToString("yyyy-MM");
            return result;
        }

        /// <summary>
        /// return date with format yyyy-MM
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToShortStringDateFormatted(this DateTime date)
        {
            return date.ToString("yyyy-MM");
        }

        /// <summary>
        /// return date with format yyyy-MM
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToYearStringDateFormatted(this DateTime date)
        {
            return date.ToString("yyyy");
        }

        /// <summary>
        /// return date with format yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToStringDateTimeFormatted(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// return nulleable date with format yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToStringDateTimeFormatted(this DateTime? date)
        {
            string result = string.Empty;
            if (date != null)
                result = Convert.ToDateTime(date).ToString("yyyy-MM-dd HH:mm:ss");
            return result;
        }

        /// <summary>
        /// return date with format yyyy-MM-dd HH:mm
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToStringDateTimeMiFormatted(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm");
        }

        /// <summary>
        /// return date with format yyyy-MM-dd HH:mm
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToStringDateMonthYearFormatted(this DateTime date)
        {
            return date.ToString("yyyy,MM");
        }

        /// <summary>
        /// return date with format yyyy-MM-dd HH:mm
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToStringDateMonthYearFormatted(this DateTime? date)
        {
            string result = string.Empty;
            if (date != null)
                result = Convert.ToDateTime(date).ToString("yyyy,MM");
            return result;
        }

        /// <summary>
        /// return date with format yyyy-MM-dd
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToStringDateMDAFormatted(this DateTime date)
        {
            return date.ToString("MM-dd-yyyy");
        }

        /// <summary>
        /// return a string wihtout spaces
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveSpaces(this string text)
        {
            return Regex.Replace(text, @"\s+", "");
        }

        /// <summary>
        /// Custom distintBy
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// Method to validate the type of the param
        /// </summary>
        /// <param name="input"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static bool Is(this string input, Type targetType)
        {
            try
            {
                TypeDescriptor.GetConverter(targetType).ConvertFromString(input);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Method to rounded a nulleable decimal.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="decimals"></param>
        /// <returns></returns>
        public static decimal Rounded(this decimal? input, int decimals)
        {
            if (input == null)
                input = 0;
            return Math.Round((decimal)input, decimals);
        }

        /// <summary>
        /// Method to rounded a decimal value.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="decimals"></param>
        /// <returns></returns>
        public static decimal Rounded(this decimal input, int decimals)
        {
            return Math.Round(input, decimals);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string SubStringRigth16(this string str)
        {
            if (str.Length > 16)
                str = str.Substring(0, 16);
            else
                str = str.PadRight(16, '0');
            return str;
        }

        public static string ToDescriptionString(this Enum val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }

        public static string ToGetSchema(this string SchemeOracle)
        {
            string sResult = String.Empty;


            if (SchemeTypeOracle.GARASEMA.ToDescriptionString().Equals(SchemeOracle))
            {

                sResult = SchemeType.SEMANAL.ToDescriptionString();

            }
            else if (SchemeTypeOracle.GARAMENS.ToDescriptionString().Equals(SchemeOracle))
            {

                sResult = SchemeType.MENSUAL.ToDescriptionString();
            }
            else
            {
                sResult = SchemeOracle;
            }



            return sResult;
        }

        public static string getDateConvert(this string sdate)
        {
            string newsDate = Convert.ToDateTime(sdate).ToStringDateFormatted();

            return newsDate;
        }


    }
}