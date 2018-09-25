using System;
using System.Collections.Generic;
using System.Linq;

namespace T9Spelling
{
    public class Parser
    {
        private Dictionary<char, string> decodeMap = new Dictionary<char, string> {
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

        public string Convert(string data)
        {
            string resultString = "";
            string[] lines = data.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            int len = lines.Length;
            if (len == 0)
                return resultString;

            for (int i = 1; i < len; i++) //started from 1, because first message informs about number of cases
            {
                string line = lines[i];
                if (line == "")
                    continue;
                string converted = ConvertLine(line);

                resultString += String.Format("Case #{0}: {1}", i, converted);
            }
            return resultString;
        }

        public string ConvertLine(string chars)
        {
            string result = "";
            chars = chars.Trim('\r', '\n');
            char[] ar = chars.ToCharArray();

            string prevVal = "";
            for (int i = 0; i < ar.Length; i++)
            {
                char val = ar[i];

                string temp = "";
                if (decodeMap.ContainsKey(val))
                {
                    temp += decodeMap[val];
                }

                if (temp == "")
                    continue;

                result += prevVal.Contains(temp[0]) ? String.Format(" {0}", temp) : temp;

                prevVal = temp;
            }

            return String.Format("{0}\r\n", result);
        }
    }
}
