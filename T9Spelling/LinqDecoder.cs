using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T9Spelling
{
    public class LinqDecoder : Decoder
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

            var result = lines.Where((line) => line != String.Empty).Select((line, index) => String.Format("Case #{0}: {1}", index, ConvertLine(line)));
            foreach (var item in result)
            {
                sb.Append(item);
            }

            return sb.ToString();
        }
    }
}
