using System;
using System.Collections.Generic;
using System.Linq;

namespace Spotify
{
    public class SpotifyPlatform
    {
        public string Name { get; }
        public List<Artist> Artists { get; }
        public List<Album> Albums { get; }
        public List<Song> Songs { get; }
        public List<User> Users { get; }
        public List<Playlist> Playlists => Users.SelectMany(user => user.Playlists).Distinct().ToList();
        public List<Song> Favorites => Users.SelectMany(user => user.Favorites).Distinct().ToList();

        public SpotifyPlatform(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Platform name is required.", nameof(name));
            }

            Name = name.Trim();
            Artists = new List<Artist>();
            Albums = new List<Album>();
            Songs = new List<Song>();
            Users = new List<User>();
        }

        public void AddArtist(Artist artist)
        {
            if (!Artists.Contains(artist))
            {
                Artists.Add(artist);
            }
        }

        public void AddAlbum(Album album)
        {
            if (!Albums.Contains(album))
            {
                Albums.Add(album);
            }

            AddArtist(album.Artist);
        }

        public void AddSong(Song song)
        {
            if (!Songs.Contains(song))
            {
                Songs.Add(song);
            }

            AddArtist(song.Owner);
            if (song.Album is not null)
            {
                AddAlbum(song.Album);
            }
        }

        public void AddUser(User user)
        {
            if (!Users.Contains(user))
            {
                Users.Add(user);
            }
        }

        public Song? FindSong(string name)
        {
            return Songs.FirstOrDefault(song =>
                song.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void PrintOverview()
        {
            Console.WriteLine($"=== {Name} ===");
            Console.WriteLine($"Artists: {Artists.Count}");
            Console.WriteLine($"Albums: {Albums.Count}");
            Console.WriteLine($"Songs: {Songs.Count}");
            Console.WriteLine($"Users: {Users.Count}");
            Console.WriteLine($"Playlists: {Playlists.Count}");
            Console.WriteLine($"Favorited songs: {Favorites.Count}");
        }
    }
}
