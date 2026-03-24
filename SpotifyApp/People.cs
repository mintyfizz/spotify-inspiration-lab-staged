using System;
using System.Collections.Generic;
using System.Linq;

namespace Spotify
{
    public class Artist
    {
        public string Name { get; }
        public List<Album> Albums { get; }
        public List<Song> Songs { get; }
        public List<Genre> Genres { get; }
        public int AlbumCount => Albums.Count;

        public Artist(string name, IEnumerable<Genre> genres)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Artist name is required.", nameof(name));
            }

            Name = name.Trim();
            Genres = genres.Distinct().ToList();
            Albums = new List<Album>();
            Songs = new List<Song>();
        }

        public void AddAlbum(Album album)
        {
            if (!Albums.Contains(album))
            {
                Albums.Add(album);
            }
        }

        public void RemoveAlbum(Album album)
        {
            Albums.Remove(album);
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

        public void AddGenre(Genre genre)
        {
            if (!Genres.Contains(genre))
            {
                Genres.Add(genre);
            }
        }

        public override string ToString()
        {
            string genres = string.Join(", ", Genres);
            return $"{Name} | Genres: {genres} | Albums: {Albums.Count} | Songs: {Songs.Count}";
        }
    }

    public class User
    {
        public string Name { get; }
        public List<Playlist> Playlists { get; }
        public HashSet<Song> Favorites { get; }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("User name is required.", nameof(name));
            }

            Name = name.Trim();
            Playlists = new List<Playlist>();
            Favorites = new HashSet<Song>();
        }

        public Playlist CreatePlaylist(string playlistName)
        {
            Playlist playlist = new Playlist(playlistName, this);
            AddPlaylist(playlist);
            return playlist;
        }

        public void AddPlaylist(Playlist playlist)
        {
            if (!Playlists.Contains(playlist))
            {
                Playlists.Add(playlist);
            }
        }

        public void RemovePlaylist(Playlist playlist)
        {
            Playlists.Remove(playlist);
        }

        public void AddFavorite(Song song)
        {
            Favorites.Add(song);
        }

        public void RemoveFavorite(Song song)
        {
            Favorites.Remove(song);
        }

        public override string ToString()
        {
            return $"{Name} | Playlists: {Playlists.Count} | Favorites: {Favorites.Count}";
        }
    }
}
