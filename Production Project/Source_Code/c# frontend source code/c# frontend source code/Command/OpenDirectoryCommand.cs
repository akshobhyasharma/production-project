using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeApp.Command
{
    class OpenDirectoryCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            if (Directory.Exists("./SavedVideo"))
            {
                string Directory = Environment.CurrentDirectory + @"\SavedVideo";
                Process.Start("explorer.exe", Directory);
            }
        }
    }
}
