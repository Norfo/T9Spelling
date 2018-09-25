using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace T9Spelling
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string smallPracticeFilePath { get; } = AppDomain.CurrentDomain.BaseDirectory + "Data\\C-small-practice.in";
        private string largePracticeFilePath { get; } = AppDomain.CurrentDomain.BaseDirectory + "Data\\C-large-practice.in";
        private string outFilePath { get; } = AppDomain.CurrentDomain.BaseDirectory + "Data\\convertedData.out";

        public string RawData { get; set; } = "";
        public string ConvertedData { get; set; } = "";

        public ICommand ReadSmallPracticeCommand
        {
            get { return new RelayCommand((object obj) => ReadPractice(smallPracticeFilePath)); }
        }

        public ICommand ReadLargePracticeCommand
        {
            get { return new RelayCommand((object obj) => ReadPractice(largePracticeFilePath)); }
        }

        public ICommand DecodeCommand
        {
            get { return new RelayCommand((object obj) => Decode()); }
        }

        public ICommand SaveFileCommand
        {
            get { return new RelayCommand((object obj) => SaveFile()); }
        }

        private void ReadPractice(string filePath)
        {
            RawData = new Reader().ReadData(filePath);
        }
        private void Decode()
        {
            ConvertedData = new Parser().Convert(RawData);
        }

        private void SaveFile()
        {
            if (ConvertedData != "")
            {
                new Writer().WriteData(ConvertedData, outFilePath);
            }
        }
    }
}
