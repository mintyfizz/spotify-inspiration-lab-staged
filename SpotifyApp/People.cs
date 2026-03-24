using System;


namespace Spotify
{
    public class Artist
    {
        public string Name { get; set; }

        public List<Album> Albums {get; set;}
        public List<Song> Songs {get; set;}

        public List<Genre> Genres {get; set;}
        public int AlbumCount {get; private set;}

public Artist (string name, List<Genre> genres)
        {
            Name = name;
            Genres = new List<Genre>(genres);
            Albums = new List<Album>();
            Songs = new List<Song>();
            AlbumCount = 0;
        
        }

        public void AddAlbum(Album album)
        {
            Albums.Add(album);
            AlbumCount++;
        }
        public void RemoveAlbum(Album album)
        {
            Albums.Remove(album);
            AlbumCount--;
        }
        public void RemoveSong(Song song)
        {
            Songs.Remove(song);
        }
        public void AddSong(Song song)
        {
            Songs.Add(song);
        }
        public void AddGenre(Genre genre)
        {
            Genres.Add(genre);
        }

        public override string ToString()
        {
            string s = $"ARTIST: {Name}\n";
            s += "Genres: ";
            foreach (Genre genre in Genres)            
            {
                s += genre.ToString() + " ";
            }
            s += "\nAlbums: ";
            foreach (Album album in Albums)
            {
                s += "\n" + album.Name;
            }
            s += "\nSongs: ";
            foreach (Song song in Songs)
            {
                s += "\n" + song.Name;
            }
            return s;
        }
    }
}
