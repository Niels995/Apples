// See https://aka.ms/new-console-template for more information
using Controller;
Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
Console.SetWindowPosition(0, 0);
Data.Initialize();
//Data.NextRace();
//Console.WriteLine(Data.CurrentRace.Track.Name);
for (; ; )
{
    Thread.Sleep(100);
}