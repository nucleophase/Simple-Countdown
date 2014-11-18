using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Simple_Countdown
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
  
        public MainWindow()
        {
            InitializeComponent();


            // Go fullscreen
            this.WindowStyle = System.Windows.WindowStyle.None;
            this.WindowState = WindowState.Maximized;
            this.Topmost = true;

            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (dateEndTime.Value != null)
            {
                
                TimeSpan timeRemaining = (TimeSpan)(dateEndTime.Value - DateTime.Now);
                labelCountdown.Content = String.Format("{0}:{1:00}:{2:00}:{3:00}", timeRemaining.Days, timeRemaining.Hours, timeRemaining.Minutes, timeRemaining.Seconds);
            }
            //http://thispointer.spaces.live.com/blog/cns!74930F9313F0A720!252.entry?_c11_blogpart_blogpart=blogview&_c=blogpart#permalink
            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
            {
                secondHand.Angle = DateTime.Now.Second * 6;
                minuteHand.Angle = DateTime.Now.Minute * 6;
                hourHand.Angle = (DateTime.Now.Hour * 30) + (DateTime.Now.Minute * 0.5);
            }));
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dateEndTime_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            dateEndTime.Visibility = System.Windows.Visibility.Collapsed;
        }

    }
}
