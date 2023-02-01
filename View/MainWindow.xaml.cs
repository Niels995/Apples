using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
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
        private void DriversChangedEventHandler(object sender, DriversChangedEventArgs eventArgs)
        {
            Renderen();
        }
        public MainWindow()
        {
            Data.Initialize();
            Data.CurrentRace.MakeTimer();
            InitializeComponent();
            Renderen();
            Data.CurrentRace.RaceDraw += RaceEventHandler!;
            Data.CurrentRace.DriversChanged += DriversChangedEventHandler!;
        }

    }
}
