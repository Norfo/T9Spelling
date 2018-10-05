using System.IO;
using System.Windows;

namespace T9Spelling
{
    public class Writer
    {
        public void WriteData(string data, string path)
        {
            if (!File.Exists(path))
                File.Create(path);

            try
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path))
                {
                    sw.Write(data);
                }
                MessageBox.Show("File successfully saved!");
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }           


        }

    }
}
