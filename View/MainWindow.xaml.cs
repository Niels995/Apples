using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Timers;

namespace WPFAppels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        //private void RaceEventHandler(object sender, RaceEventArgs eventArgs)
        //{
        //    //Container.Dispatcher.BeginInvoke(
        //    //    DispatcherPriority.Render,
        //    //    new Action(() =>
        //    //    {
        //    //        Color color = Color.FromArgb(eventArgs.Color.A, eventArgs.Color.R, eventArgs.Color.G,
        //    //            eventArgs.Color.B);
        //    //        Container.Background = new SolidColorBrush(color);
        //    //    }));
        //    Render.DrawTrack(Data.CurrentRace.Track);
        //}

        private void RaceEventHandler(object sender, RaceEventArgs eventArgs)
        {
            //Container.Dispatcher.BeginInvoke(
            //    DispatcherPriority.Render,
            //    new Action(() =>
            //    {
            //        //Color color = Color.FromArgb(eventArgs.Color.A, eventArgs.Color.R, eventArgs.Color.G,
            //        //    eventArgs.Color.B);
            //        //Container.Background = new SolidColorBrush(color);
            //    }));
        }
        private void Renderen()
        {
            TrackImage.Dispatcher.BeginInvoke(
                DispatcherPriority.Render,
                new Action(() =>
                {
                    TrackImage.Source = null;
                    TrackImage.Source = Render.DrawTrack(Data.CurrentRace.Track);
                }));
        }
        private void RenderenChanged(object sender, DriversChangedEventArgs eventArgs)
        {
            Renderen();
        }

        private static System.Timers.Timer Timer;
        public void MakeTimer()
        {
            Start();
            Timer.Start();
            //Console.ReadLine();
            //Timer.Stop();
        }
        private void Start()
        {
            // Create a timer with a two second interval.
            Timer = new System.Timers.Timer(500);
            // Hook up the Elapsed event for the timer. 
            Timer.Elapsed += OnTimedEvent!;
            Timer.AutoReset = true;
            Timer.Enabled = true;
        }
        public void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Renderen();
        }
        public MainWindow()
        {
            Data.Initialize();
            MakeTimer();
            InitializeComponent();
            //Data.CurrentRace.RaceDraw += RaceEventHandler!;
            //Data.CurrentRace.DriversChanged += RenderenChanged!;
        }
        private void WindowClosed(object? sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItemExitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
