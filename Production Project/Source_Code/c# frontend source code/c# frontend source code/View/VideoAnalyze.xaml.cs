using AnalyzeApp.ViewModel;
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
using System.Windows.Threading;

namespace AnalyzeApp.View
{
    /// <summary>
    /// Interaction logic for VideoAnalyze.xaml
    /// </summary>
    public partial class VideoAnalyze : UserControl
    {
        DispatcherTimer timer;
        public VideoAnalyze()
        {

            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += new EventHandler(Timer_Tick);
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            VideoSlider.Value = MediaElementUpload.Position.TotalSeconds;
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            MediaElementUpload.Play();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            MediaElementUpload.Pause();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            MediaElementUpload.Stop();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MediaElementUpload.Position = TimeSpan.FromSeconds(VideoSlider.Value);
        }

        private void MediaElementUpload_MediaOpened(object sender, RoutedEventArgs e)
        {
            TimeSpan ts = MediaElementUpload.NaturalDuration.TimeSpan;
            VideoSlider.Maximum = ts.TotalSeconds;
            timer.Start();
        }

        private void VideoSlider_DragLeave(object sender, DragEventArgs e)
        {
            MediaElementUpload.Position = TimeSpan.FromSeconds(VideoSlider.Value);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MediaElementUpload.Stop();
            MediaElementUpload.Source = null;
        }
    }
}
