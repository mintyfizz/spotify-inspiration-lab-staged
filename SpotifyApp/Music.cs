using System;
using System.Collections.Generic;
using System.Linq;

namespace Spotify
{
    public enum Genre
    {
        Pop,
        Rock,
        HipHop,
        Jazz,
        Classical,
        Country,
        Alternative,
        RnB,
        Funk,
        Indie,
        Latin,
        World,
        Gospel,
        Opera,
        Electronic,
        Reggae,
        Blues,
        Rap,
        Punk,
        Swing,
        Disco,
        Dance,
        Folk,
        Metal,
        Soul,
        Ambient
    }

    public class Song
    {
        public string Name { get; }
        public Album? Album { get; internal set; }
        public bool HasLyrics { get; }
        public Artist Owner { get; }
        public int Duration { get; }
        public Genre Genre { get; }
        public DateOnly ReleaseDate { get; }
        public bool IsPaused { get; private set; }

        public Song(string name, Artist owner, bool hasLyrics, Genre genre, int duration, DateOnly releaseDate)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Song name is required.", nameof(name));
            }

            if (duration <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(duration), "Duration must be positive.");
            }

            Name = name.Trim();
            Owner = owner;
            HasLyrics = hasLyrics;
            Genre = genre;
            Duration = duration;
            ReleaseDate = releaseDate;
            Owner.AddSong(this);
        }

        public void Play()
        {
            IsPaused = false;
            Console.WriteLine($"NOW PLAYING: {Name} by {Owner.Name}");
        }

        public void Pause()
        {
            IsPaused = true;
            Console.WriteLine($"PAUSED: {Name} by {Owner.Name}");
        }

        public override string ToString()
        {
            string albumName = Album is null ? "Single" : Album.Name;
            return $"{Name} | {Owner.Name} | Album: {albumName} | Genre: {Genre} | Duration: {Duration}s | Lyrics: {HasLyrics} | Release: {ReleaseDate:yyyy-MM-dd}";
        }
    }

    public class Album
    {
        public string Name { get; }
        public Genre Genre { get; }
        public DateOnly ReleaseDate { get; }
        public Artist Artist { get; }
        public List<Song> Songs { get; }
        public int Duration => Songs.Sum(song => song.Duration);

        public Album(string name, Genre genre, DateOnly releaseDate, Artist artist)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Album name is required.", nameof(name));
            }

            Name = name.Trim();
            Genre = genre;
            ReleaseDate = releaseDate;
            Artist = artist;
            Songs = new List<Song>();
            Artist.AddAlbum(this);
        }

        public void AddSong(Song song)
        {
            if (Songs.Contains(song))
            {
                return;
            }

            if (song.Album is not null && song.Album != this)
            {
                song.Album.RemoveSong(song);
            }

            Songs.Add(song);
            song.Album = this;
            Artist.AddSong(song);
        }

        public void RemoveSong(Song song)
        {
            if (!Songs.Remove(song))
            {
                return;
            }

            if (song.Album == this)
            {
                song.Album = null;
            }
        }

        public void Play()
        {
            Console.WriteLine($"NOW PLAYING ALBUM: {Name} by {Artist.Name}");
            foreach (Song song in Songs)
            {
                song.Play();
            }
        }

        public void Pause()
        {
            Console.WriteLine($"PAUSED ALBUM: {Name} by {Artist.Name}");
        }

        public override string ToString()
        {
            return $"{Name} | {Artist.Name} | Genre: {Genre} | Songs: {Songs.Count} | Duration: {Duration}s | Release: {ReleaseDate:yyyy-MM-dd}";
        }
    }

    public class Playlist
    {
        public string Name { get; }
        public User Owner { get; }
        public List<Song> Songs { get; }
        public int Duration => Songs.Sum(song => song.Duration);

        public Playlist(string name, User owner)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Playlist name is required.", nameof(name));
            }

            Name = name.Trim();
            Owner = owner;
            Songs = new List<Song>();
        }

        public void AddSong(Song song)
        {
            if (!Songs.Contains(song))
            {
                Songs.Add(song);
            }
        }

        public void RemoveSong(Song song)
        {
            Songs.Remove(song);
        }

        public void Play()
        {
            Console.WriteLine($"NOW PLAYING PLAYLIST: {Name} (Owner: {Owner.Name})");
            foreach (Song song in Songs)
            {
                song.Play();
            }
        }

        public void Pause()
        {
            Console.WriteLine($"PAUSED PLAYLIST: {Name} (Owner: {Owner.Name})");
        }

        public override string ToString()
        {
            return $"{Name} | Songs: {Songs.Count} | Duration: {Duration}s";
        }
    }
}
