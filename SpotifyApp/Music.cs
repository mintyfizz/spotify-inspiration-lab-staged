using System;
using System.Collections.Generic;
using System.Threading;

namespace Spotify
{

    public class Album
    {
        public string Name {get; set;}
        public List<Song> Songs {get; set;}
        public int Amount {get; private set;}
        public DateOnly RealeaseDate {get; set;}
        public Artist Artist {get; set;}
        public int Duration {get; set;}

        public Album(string name, DateOnly ReleaseDate, Artist artist)
        {
            Name = name; Songs = new List<Song>(); Amount = 0; 
            RealeaseDate = ReleaseDate; 
            Artist = artist; 
            Duration = 0;
        }
        public void Play()
        {
            Console.WriteLine($"NOW PLAYING ALBUM: {Name} by {Artist.Name}\n");
            foreach (Song song in Songs)
            {
                song.Play();
            }
        }

        public override string ToString()
        {
            string s = $"ALBUM: {Name} by {Artist.Name}";
            foreach (Song song in Songs)
            {
                s += "\n" + song.ToString();
            }
            return s;
            
        }
    }

    public enum Genre
    {
        Pop, Rock, HipHop, Jazz, Classical, Country, Alternative, RnB, Funk, Indie, Latin, World, Gospel, Opera,
        Electronic, Reggae, Blues, Rap, Punk, Swing, Disco, Dance, Folk, Metal, Soul, Ambient
    }
    public class Song
    {
        public string Name { get; set; }
        public Artist Owner { get; set; }
        public bool HasLyrics {get; private set;}
        public Genre G { get; set; }
        public int Duration { get; set; }
        
        public bool Like { get; set; }
        public Song(string name, Artist owner, bool hasLyrics, Genre genre, int duration, bool like)
        {
            Name = name;
            Owner = owner;
            HasLyrics = hasLyrics;
            G = genre;
            Duration = duration;
            Like = like;
            Owner.Songs.Add(this); // testing 
        }
        public void Play()
        {
            // We will be playing the title, followed by x seconds of nothing
            // pc cannot do anything while Thread.Sleep()
            Console.WriteLine($"NOW PLAYING: {Name} by {Owner.Name}");
            for (int i = 0; i < Duration; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine("\nSong ended.");
        }

        public override String ToString()
        {
            return $"SONG: {Name} by {Owner.Name} - Genre: {G}, Duration: {Duration} seconds, Has Lyrics: {HasLyrics}, Liked: {Like}";
        }


    }
}
