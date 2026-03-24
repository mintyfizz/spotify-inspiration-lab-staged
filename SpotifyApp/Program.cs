using System;
using System.Collections.Generic;

namespace Spotify
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Artist ImagineDragons = new Artist("Imagine Dragons", new List<Genre>{Genre.Rock, Genre.Alternative});
            Artist BoweryElectric = new Artist("Bowery Electric", new List<Genre>{Genre.Electronic, Genre.Ambient});
            Artist TheWeeknd = new Artist("The Weeknd", new List<Genre>{Genre.RnB, Genre.Pop});
            Artist KendrickLamar = new Artist("Kendrick Lamar", new List<Genre>{Genre.HipHop, Genre.Rap});
            Artist TaylorSwift = new Artist("Taylor Swift", new List<Genre>{Genre.Pop, Genre.Country});


            Song BlindingLights = new Song("Blinding Lights", TheWeeknd, true, Genre.RnB, 2, true);
            Song Starboy = new Song("Starboy", TheWeeknd, true, Genre.RnB, 2, true);
            Song Humble = new Song("HUMBLE", KendrickLamar, true, Genre.HipHop, 1, true);
            Song DNA = new Song("DNA", KendrickLamar, true, Genre.HipHop, 2, true);
            Song Radioactive = new Song("Radioactive", ImagineDragons, true, Genre.Rock, 2, true);
            Song Believer = new Song("Believer", ImagineDragons, true, Genre.Rock, 2, true);
            Song LazyEye = new Song("Lazy Eye", BoweryElectric, true, Genre.Electronic, 2, true);
            Song Deepthroat = new Song("Deepthroat", BoweryElectric, true, Genre.Ambient, 2, true);
            Song LoveStory = new Song("Love Story", TaylorSwift, true, Genre.Country, 2, true);
            Song ShakeItOff = new Song("Shake It Off", TaylorSwift, true, Genre.Pop, 2, true);


            foreach (Song song in ImagineDragons.Songs)
            {
                Console.WriteLine(song.ToString());
            }
        



        }
    }
}
