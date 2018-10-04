using System;
using System.ComponentModel;
using System.Windows.Input;

namespace T9Spelling
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Variables
        private string smallPracticeFilePath { get; } = AppDomain.CurrentDomain.BaseDirectory + "Data\\C-small-practice.in";
        private string largePracticeFilePath { get; } = AppDomain.CurrentDomain.BaseDirectory + "Data\\C-large-practice.in";
        private string outFilePath { get; } = AppDomain.CurrentDomain.BaseDirectory + "Data\\convertedData.out";

        public string RawData { get; set; } = "";
        public string ConvertedData { get; set; } = "";

        public bool IsLinqDecoderSelected { get; set; } = false;
        #endregion

        #region Commands
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
        #endregion

        #region Methods
        private void ReadPractice(string filePath)
        {
            RawData = new Reader().ReadData(filePath);
        }
        private void Decode()
        {
            ConvertedData = IsLinqDecoderSelected ? new LinqDecoder().Convert(RawData) : new LoopDecoder().Convert(RawData);
        }

        private void SaveFile()
        {
            if (ConvertedData != "")
            {
                new Writer().WriteData(ConvertedData, outFilePath);
            }
        }
        #endregion
    }
}
