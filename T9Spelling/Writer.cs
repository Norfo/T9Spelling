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

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path))
            {
                sw.WriteLine(data);
                sw.Close();
            }                

            MessageBox.Show("File successfully saved!");
        }

    }
}
