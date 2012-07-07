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
            if (dateEndTime.SelectedDate != null)
            {
                
                TimeSpan timeRemaining = dateEndTime.SelectedDate.Value.Subtract(DateTime.Now);
                timeRemaining = timeRemaining.Add(new TimeSpan(9, 0, 0)); // This sets it to 9am. Always 9am. Because that's what I want. Change the 9 to change the time.
                labelCountdown.Content = String.Format("{0}:{1:00}:{2:00}:{3:00}", timeRemaining.Days, timeRemaining.Hours, timeRemaining.Minutes, timeRemaining.Seconds);
            }
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dateEndTime_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dateEndTime.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}
