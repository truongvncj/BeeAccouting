using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEEACCOUNT.shared
{
    public static class StringExtensions
    {


        public static string Right(this string str, int length)
        {

            if (str.Length - length > 0)
            {
                return str.Substring(str.Length - length, length);

            }
            else
            {
                return str;
            }





        }

        public static string Truncate(this string source, int length)
        {
            if (source != null)
            {
                if (source.Length > length)
                {
                    return source.Substring(0, length);
                }
                return source;
            }
            else
            {
                return " ";
            }

        }
    }
}
