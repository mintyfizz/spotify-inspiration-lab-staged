using System;
using System.Linq;

namespace Spotify
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SpotifyPlatform platform = new SpotifyPlatform("Spotify InspirationLab");
            platform.PopulateDemoData();

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
            Playlist? firstPlaylist = platform.Playlists.FirstOrDefault();
            Song? firstSong = platform.Songs.FirstOrDefault();
            Album? firstAlbum = platform.Albums.FirstOrDefault();

            if (firstPlaylist is not null)
            {
                firstPlaylist.Play();
                firstPlaylist.Pause();
            }

            if (firstSong is not null)
            {
                firstSong.Play();
                firstSong.Pause();
            }

            if (firstAlbum is not null)
            {
                firstAlbum.Play();
                firstAlbum.Pause();
            }

            Console.WriteLine();
            Song? foundSong = platform.FindSong("HUMBLE.");
            Console.WriteLine(foundSong is null ? "Song not found." : $"Found song: {foundSong}");
        }
    }
}
