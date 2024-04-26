using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
// Add NS
using System.Timers;
using Timer = System.Timers.Timer;

namespace GenGamesV1
{
    /// <summary>
    /// Interaction logic for LoadingScreen.xaml
    /// </summary>
    public partial class LoadingScreen : Window
    {

        // Add the timer function
        private Timer pBarTimer;

        public LoadingScreen()
        {
            InitializeComponent();
            // Start the Loading Process
            Load();
        }

        // Method to Initialise the Progress Bar Timer
        public void Load()
        {
            // Create the new time with the tick interval of 16 milliseconds
            pBarTimer = new Timer(16);

            // Subscribe to the Elapsed Event

            pBarTimer.Elapsed += new ElapsedEventHandler(Timer_Tick);

            // Start the Timer
            pBarTimer.Start();
        }
        // Event Handler for the timer tick
        private void Timer_Tick(object sender, ElapsedEventArgs e)
        {
            // Invoke the Update on the UI THread
            Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)(() =>
                {

                    if (ProgBar.Value < 100)
                    {
#if DEBUG
                        ProgBar.Value += 1;
#else
                        ProgBar.Value += 0.4;
#endif
                    }
                    else
                    {
                        pBarTimer.Stop();
                        // Create a new Login Window
                        Login window = new Login();
                        // Close the Loading Screen Window
                        this.Close();
                        // Show the Login Window
                        window.ShowDialog();
                    }
                }));

            //throw new NotImplementedException();
        }
    }
}
