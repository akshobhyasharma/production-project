using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnalyzeApp.View
{
    /// <summary>
    /// Interaction logic for VideoLibrary.xaml
    /// </summary>
    public partial class VideoLibrary : UserControl
    {
        public VideoLibrary()
        {
            InitializeComponent();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            MediaElementUpload.LoadedBehavior = MediaState.Manual;
            MediaElementUpload.Play();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            MediaElementUpload.LoadedBehavior = MediaState.Manual;
            MediaElementUpload.Pause();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            MediaElementUpload.LoadedBehavior = MediaState.Manual;
            MediaElementUpload.Stop();
        }

        private void PackIconMaterial_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();


            openFileDialog.InitialDirectory = "c:";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == true)
            {
                //Get the path of specified file
                VideoPathTextbox.Text = openFileDialog.FileName;
            }
        }
    }
}
