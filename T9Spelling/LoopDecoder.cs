using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T9Spelling
{
    public class LoopDecoder : Decoder
    {
        /// <summary>
        /// Decode text to digital code
        /// </summary>
        /// <param name="data">Input text</param>
        /// <returns>Digital code</returns>
        public override string Convert(string data)
        {
            StringBuilder sb = new StringBuilder();
            string[] lines = data.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            int len = lines.Length;

            if (len == 0)
                return sb.ToString();

            for (int i = 1; i < len; i++) //started from 1, because first message informs about number of cases
            {
                string line = lines[i];
                if (line == String.Empty)
                    continue;

                string converted = ConvertLine(line);

                if (converted == String.Empty)
                    continue;

                sb.Append(String.Format("Case #{0}: {1}", i, converted));
            }

            return sb.ToString();
        }
    }
}
