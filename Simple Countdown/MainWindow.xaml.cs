using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Media;
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
        TimeSpan timeRemaining = new TimeSpan(0, 5, 0);

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
            if (!string.IsNullOrEmpty(endTime.Text))
            {
                int minutes = 0;
                int.TryParse(endTime.Text, out minutes);
                timeRemaining = new TimeSpan(0, minutes, 0);
                endTime.Text = "";
            }
            if (timeRemaining.Seconds <= 0)
            {
                Task.Factory.StartNew(() =>
                {
                    SystemSounds.Beep.Play();
                });
            }
            labelCountdown.Content = String.Format("{0}:{1:00}:{2:00}:{3:00}", timeRemaining.Days, timeRemaining.Hours, timeRemaining.Minutes, timeRemaining.Seconds);
            timeRemaining = timeRemaining.Subtract(new TimeSpan(0, 0, 1));

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
    }
}
