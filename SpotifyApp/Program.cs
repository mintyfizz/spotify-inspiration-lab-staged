using System;
using System.Collections.Generic;

namespace Spotify
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SpotifyPlatform platform = new SpotifyPlatform("Spotify InspirationLab");

            Artist imagineDragons = new Artist("Imagine Dragons", new List<Genre> { Genre.Rock, Genre.Alternative });
            Artist theWeeknd = new Artist("The Weeknd", new List<Genre> { Genre.RnB, Genre.Pop });
            Artist kendrickLamar = new Artist("Kendrick Lamar", new List<Genre> { Genre.HipHop, Genre.Rap });
            Artist taylorSwift = new Artist("Taylor Swift", new List<Genre> { Genre.Pop, Genre.Country });

            platform.AddArtist(imagineDragons);
            platform.AddArtist(theWeeknd);
            platform.AddArtist(kendrickLamar);
            platform.AddArtist(taylorSwift);

            Album evolve = new Album("Evolve", Genre.Rock, new DateOnly(2017, 6, 23), imagineDragons);
            Album starboyAlbum = new Album("Starboy", Genre.RnB, new DateOnly(2016, 11, 25), theWeeknd);
            Album damn = new Album("DAMN.", Genre.HipHop, new DateOnly(2017, 4, 14), kendrickLamar);
            Album fearLess = new Album("Fearless", Genre.Country, new DateOnly(2008, 11, 11), taylorSwift);

            platform.AddAlbum(evolve);
            platform.AddAlbum(starboyAlbum);
            platform.AddAlbum(damn);
            platform.AddAlbum(fearLess);

            Song radioactive = new Song("Radioactive", imagineDragons, true, Genre.Rock, 186, new DateOnly(2012, 2, 14));
            Song believer = new Song("Believer", imagineDragons, true, Genre.Rock, 204, new DateOnly(2017, 2, 1));
            Song blindingLights = new Song("Blinding Lights", theWeeknd, true, Genre.RnB, 200, new DateOnly(2019, 11, 29));
            Song starboy = new Song("Starboy", theWeeknd, true, Genre.RnB, 230, new DateOnly(2016, 9, 22));
            Song humble = new Song("HUMBLE.", kendrickLamar, true, Genre.HipHop, 177, new DateOnly(2017, 3, 30));
            Song dna = new Song("DNA.", kendrickLamar, true, Genre.HipHop, 185, new DateOnly(2017, 4, 14));
            Song loveStory = new Song("Love Story", taylorSwift, true, Genre.Country, 236, new DateOnly(2008, 9, 12));
            Song shakeItOff = new Song("Shake It Off", taylorSwift, true, Genre.Pop, 219, new DateOnly(2014, 8, 18));

            evolve.AddSong(radioactive);
            evolve.AddSong(believer);
            starboyAlbum.AddSong(blindingLights);
            starboyAlbum.AddSong(starboy);
            damn.AddSong(humble);
            damn.AddSong(dna);
            fearLess.AddSong(loveStory);
            fearLess.AddSong(shakeItOff);

            platform.AddSong(radioactive);
            platform.AddSong(believer);
            platform.AddSong(blindingLights);
            platform.AddSong(starboy);
            platform.AddSong(humble);
            platform.AddSong(dna);
            platform.AddSong(loveStory);
            platform.AddSong(shakeItOff);

            User alex = new User("Alex");
            User sam = new User("Sam");
            platform.AddUser(alex);
            platform.AddUser(sam);

            Playlist morningRun = alex.CreatePlaylist("Morning Run");
            morningRun.AddSong(believer);
            morningRun.AddSong(blindingLights);
            morningRun.AddSong(humble);

            Playlist chillNight = sam.CreatePlaylist("Chill Night");
            chillNight.AddSong(starboy);
            chillNight.AddSong(loveStory);
            chillNight.AddSong(shakeItOff);

            alex.AddFavorite(blindingLights);
            alex.AddFavorite(humble);
            sam.AddFavorite(loveStory);
            sam.AddFavorite(starboy);

            platform.PrintOverview();
            Console.WriteLine();

            Console.WriteLine("Artists:");
            foreach (Artist artist in platform.Artists)
            {
                Console.WriteLine(artist);
            }

            Console.WriteLine();
            Console.WriteLine("Albums:");
            foreach (Album album in platform.Albums)
            {
                Console.WriteLine(album);
            }

            Console.WriteLine();
            Console.WriteLine("Users:");
            foreach (User user in platform.Users)
            {
                Console.WriteLine(user);
            }

            Console.WriteLine();
            Console.WriteLine("Playlists:");
            foreach (Playlist playlist in platform.Playlists)
            {
                Console.WriteLine(playlist);
            }

            Console.WriteLine();
            Console.WriteLine("Playback demo:");
            morningRun.Play();
            morningRun.Pause();
            radioactive.Play();
            radioactive.Pause();
            evolve.Play();
            evolve.Pause();

            Console.WriteLine();
            Song? foundSong = platform.FindSong("HUMBLE.");
            Console.WriteLine(foundSong is null ? "Song not found." : $"Found song: {foundSong}");
        }
    }
}
