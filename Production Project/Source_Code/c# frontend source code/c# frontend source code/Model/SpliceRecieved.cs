using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeApp.Model
{
    public class SpliceRecieved: INotifyPropertyChanged
    {
        public int id { get; set; }
        public string? videoName { get; set; }
        public int starttime { get; set; }
        public int endTime { get; set; }
        public string? spliceName { get; set; }
        public List<String>? objectList { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
