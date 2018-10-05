using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T9Spelling
{
    public class Decoder
    {
        private static Dictionary<char, string> decodeMap = new Dictionary<char, string> {
            {' ', "0" },
            {'a', "2" },
            {'b', "22" },
            {'c', "222" },
            {'d', "3" },
            {'e', "33" },
            {'f', "333" },
            {'g', "4" },
            {'h', "44" },
            {'i', "444" },
            {'j', "5" },
            {'k', "55" },
            {'l', "555" },
            {'m', "6" },
            {'n', "66" },
            {'o', "666" },
            {'p', "7" },
            {'q', "77" },
            {'r', "777" },
            {'s', "7777" },
            {'t', "8" },
            {'u', "88" },
            {'v', "888" },
            {'w', "9" },
            {'x', "99" },
            {'y', "999" },
            {'z', "9999" },
        };

        public virtual string Convert(string data)
        {
            return String.Empty;
        }

        /// <summary>
        /// Decode text line to digital code
        /// </summary>
        /// <param name="chars">Input text line</param>
        /// <returns>Digital code line</returns>
        public string ConvertLine(string chars)
        {
            StringBuilder result = new StringBuilder(chars.Length);

            chars = chars.Trim('\r', '\n');

            string prevVal = String.Empty;
            for (int i = 0; i < chars.Length; i++)
            {
                char val = chars[i];

                string temp = String.Empty;

                if (!decodeMap.ContainsKey(val))
                    continue;

                temp = decodeMap[val];

                result.Append(prevVal.Contains(temp[0]) ? String.Format(" {0}", temp) : temp);

                prevVal = temp;
            }

            if (result.Length == 0)
                return result.ToString();

            return String.Format("{0}{1}", result.ToString(), Environment.NewLine);
        }
    }
}
