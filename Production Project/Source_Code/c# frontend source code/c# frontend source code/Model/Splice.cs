using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeApp.Model
{
    class Splice
    {
        public Splice(string speed, string videoName, List<string> parameters)
        {
            this.videoName = videoName;
            this.speed = speed;            
            this.parameters = parameters;
        }
        public string videoName { get; set; }
        public string speed { get; set; }
        public List<String> parameters { get; set; }
    }
}
