// See https://aka.ms/new-console-template for more information
using Controller;
using Model;
namespace Appels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Data.Initialize();
            Visual.Initialize(Data.CurrentRace);
            //Data.NextRace();
            //Console.WriteLine(Data.CurrentRace.Track.Name);
            Data.CurrentRace.DriversChanged += (sender, e) =>
            {
                Object ne2 = sender;
                Data.CurrentRace.MoveTrack(e.track);
                Data.CurrentRace.StartRace(e.x, e.y, e.track);
                Visual.Visualise(e.x, e.y, e.track);
            };
            for (; ; )
            {
                Thread.Sleep(100);
            }
        }
    }
}