using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
namespace BookShopCourseWork.Extensions
{
    public class AlphanumComparatorFast : IComparer<string>, IComparer
    {
        public int Compare(string x, string y)
        {
            if (x == null)
            {
                return 0;
            }
            if (y == null)
            {
                return 0;
            }

            int len1 = x.Length;
            int len2 = y.Length;
            int marker1 = 0;
            int marker2 = 0;

            while (marker1 < len1 && marker2 < len2)
            {
                char ch1 = x[marker1];
                char ch2 = y[marker2];

                var space1 = new char[len1];
                int loc1 = 0;
                var space2 = new char[len2];
                int loc2 = 0;

                do
                {
                    space1[loc1++] = ch1;
                    marker1++;

                    if (marker1 < len1)
                    {
                        ch1 = x[marker1];
                    }
                    else
                    {
                        break;
                    }
                } while (char.IsDigit(ch1) == char.IsDigit(space1[0]));

                do
                {
                    space2[loc2++] = ch2;
                    marker2++;

                    if (marker2 < len2)
                    {
                        ch2 = y[marker2];
                    }
                    else
                    {
                        break;
                    }
                } while (char.IsDigit(ch2) == char.IsDigit(space2[0]));

                var str1 = new string(space1);
                var str2 = new string(space2);

                int result;

                if (char.IsDigit(space1[0]) && char.IsDigit(space2[0]))
                {
                    int thisNumericChunk = int.Parse(str1);
                    int thatNumericChunk = int.Parse(str2);
                    result = thisNumericChunk.CompareTo(thatNumericChunk);
                }
                else
                {
                    result = System.String.Compare(str1.Replace(" ", ""), str2.Replace(" ", ""), System.StringComparison.InvariantCultureIgnoreCase);
                }

                if (result != 0)
                {
                    return result;
                }
            }
            return len1 - len2;
        }

        public int Compare(object x, object y)
        {
            return this.Compare(x as string, y as string);
        }
    }
}