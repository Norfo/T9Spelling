using System;
using System.IO;
using System.Windows;

namespace T9Spelling
{
    public class Reader
    {
        public string ReadData(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line = sr.ReadToEnd();
                    return line;
                }
            }
            catch (Exception e)
            {                
                MessageBox.Show(e.Message);
                return "";
            }
        }
    }
}
