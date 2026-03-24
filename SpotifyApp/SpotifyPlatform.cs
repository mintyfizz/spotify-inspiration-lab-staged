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

        public void PopulateDemoData()
        {
            if (Artists.Count > 0 || Albums.Count > 0 || Songs.Count > 0 || Users.Count > 0)
            {
                return;
            }

            Artist imagineDragons = new Artist("Imagine Dragons", new[] { Genre.Rock, Genre.Alternative });
            Artist theWeeknd = new Artist("The Weeknd", new[] { Genre.RnB, Genre.Pop });
            Artist kendrickLamar = new Artist("Kendrick Lamar", new[] { Genre.HipHop, Genre.Rap });
            Artist taylorSwift = new Artist("Taylor Swift", new[] { Genre.Pop, Genre.Country });
            Artist daftPunk = new Artist("Daft Punk", new[] { Genre.Electronic, Genre.Dance });
            Artist billieEilish = new Artist("Billie Eilish", new[] { Genre.Pop, Genre.Indie });
            Artist arcticMonkeys = new Artist("Arctic Monkeys", new[] { Genre.Rock, Genre.Indie });
            Artist duaLipa = new Artist("Dua Lipa", new[] { Genre.Pop, Genre.Dance });
            Artist adele = new Artist("Adele", new[] { Genre.Pop, Genre.Soul });
            Artist coldplay = new Artist("Coldplay", new[] { Genre.Rock, Genre.Alternative });

            AddArtist(imagineDragons);
            AddArtist(theWeeknd);
            AddArtist(kendrickLamar);
            AddArtist(taylorSwift);
            AddArtist(daftPunk);
            AddArtist(billieEilish);
            AddArtist(arcticMonkeys);
            AddArtist(duaLipa);
            AddArtist(adele);
            AddArtist(coldplay);

            AddAlbumWithSongs(
                imagineDragons,
                "Evolve",
                Genre.Rock,
                new DateOnly(2017, 6, 23),
                ("Believer", Genre.Rock, 204, new DateOnly(2017, 2, 1)),
                ("Thunder", Genre.Rock, 187, new DateOnly(2017, 4, 27)),
                ("Whatever It Takes", Genre.Rock, 201, new DateOnly(2017, 5, 8))
            );

            AddAlbumWithSongs(
                theWeeknd,
                "After Hours",
                Genre.RnB,
                new DateOnly(2020, 3, 20),
                ("Blinding Lights", Genre.RnB, 200, new DateOnly(2019, 11, 29)),
                ("Save Your Tears", Genre.Pop, 215, new DateOnly(2020, 3, 20)),
                ("In Your Eyes", Genre.RnB, 238, new DateOnly(2020, 3, 20))
            );

            AddAlbumWithSongs(
                kendrickLamar,
                "DAMN.",
                Genre.HipHop,
                new DateOnly(2017, 4, 14),
                ("HUMBLE.", Genre.HipHop, 177, new DateOnly(2017, 3, 30)),
                ("DNA.", Genre.HipHop, 185, new DateOnly(2017, 4, 14)),
                ("LOYALTY.", Genre.HipHop, 227, new DateOnly(2017, 4, 14))
            );

            AddAlbumWithSongs(
                taylorSwift,
                "1989",
                Genre.Pop,
                new DateOnly(2014, 10, 27),
                ("Shake It Off", Genre.Pop, 219, new DateOnly(2014, 8, 18)),
                ("Blank Space", Genre.Pop, 231, new DateOnly(2014, 11, 10)),
                ("Style", Genre.Pop, 231, new DateOnly(2015, 2, 9))
            );

            AddAlbumWithSongs(
                daftPunk,
                "Random Access Memories",
                Genre.Electronic,
                new DateOnly(2013, 5, 17),
                ("Get Lucky", Genre.Dance, 248, new DateOnly(2013, 4, 19)),
                ("Instant Crush", Genre.Electronic, 337, new DateOnly(2013, 5, 17)),
                ("Lose Yourself to Dance", Genre.Dance, 353, new DateOnly(2013, 5, 17))
            );

            AddAlbumWithSongs(
                billieEilish,
                "Happier Than Ever",
                Genre.Indie,
                new DateOnly(2021, 7, 30),
                ("bad guy", Genre.Pop, 194, new DateOnly(2019, 3, 29)),
                ("Therefore I Am", Genre.Pop, 174, new DateOnly(2020, 11, 12)),
                ("Happier Than Ever", Genre.Indie, 298, new DateOnly(2021, 7, 30))
            );

            AddAlbumWithSongs(
                arcticMonkeys,
                "AM",
                Genre.Indie,
                new DateOnly(2013, 9, 9),
                ("Do I Wanna Know?", Genre.Indie, 272, new DateOnly(2013, 6, 19)),
                ("R U Mine?", Genre.Rock, 201, new DateOnly(2012, 2, 27)),
                ("Why'd You Only Call Me When You're High?", Genre.Indie, 161, new DateOnly(2013, 8, 11))
            );

            AddAlbumWithSongs(
                duaLipa,
                "Future Nostalgia",
                Genre.Dance,
                new DateOnly(2020, 3, 27),
                ("Levitating", Genre.Dance, 203, new DateOnly(2020, 3, 27)),
                ("Physical", Genre.Dance, 194, new DateOnly(2020, 1, 30)),
                ("Don't Start Now", Genre.Pop, 183, new DateOnly(2019, 10, 31))
            );

            AddAlbumWithSongs(
                adele,
                "25",
                Genre.Soul,
                new DateOnly(2015, 11, 20),
                ("Hello", Genre.Soul, 295, new DateOnly(2015, 10, 23)),
                ("Send My Love", Genre.Pop, 223, new DateOnly(2016, 5, 16)),
                ("When We Were Young", Genre.Soul, 289, new DateOnly(2016, 1, 22))
            );

            AddAlbumWithSongs(
                coldplay,
                "A Rush of Blood to the Head",
                Genre.Alternative,
                new DateOnly(2002, 8, 26),
                ("Clocks", Genre.Alternative, 307, new DateOnly(2003, 3, 24)),
                ("The Scientist", Genre.Alternative, 309, new DateOnly(2002, 11, 11)),
                ("In My Place", Genre.Rock, 228, new DateOnly(2002, 8, 5))
            );

            User alex = new User("Alex");
            User sam = new User("Sam");
            User priya = new User("Priya");
            User jordan = new User("Jordan");
            User luis = new User("Luis");

            AddUser(alex);
            AddUser(sam);
            AddUser(priya);
            AddUser(jordan);
            AddUser(luis);

            CreatePlaylistWithSongs(alex, "Morning Run", "Believer", "Levitating", "HUMBLE.", "Blinding Lights", "Do I Wanna Know?");
            CreatePlaylistWithSongs(alex, "Focus Mode", "Clocks", "The Scientist", "Instant Crush", "In Your Eyes");
            CreatePlaylistWithSongs(sam, "Party Mix", "Get Lucky", "Don't Start Now", "Shake It Off", "Save Your Tears");
            CreatePlaylistWithSongs(sam, "Night Drive", "Style", "Blinding Lights", "R U Mine?", "In My Place");
            CreatePlaylistWithSongs(priya, "Throwbacks", "Hello", "Style", "The Scientist", "Blank Space");
            CreatePlaylistWithSongs(priya, "Pop Hits", "bad guy", "Levitating", "Save Your Tears", "Shake It Off");
            CreatePlaylistWithSongs(jordan, "Hip-Hop Core", "HUMBLE.", "DNA.", "LOYALTY.");
            CreatePlaylistWithSongs(jordan, "Indie Vibes", "Do I Wanna Know?", "Why'd You Only Call Me When You're High?", "Happier Than Ever");
            CreatePlaylistWithSongs(luis, "Coding Playlist", "Clocks", "Believer", "Get Lucky", "Instant Crush", "Physical");
            CreatePlaylistWithSongs(luis, "Late Night", "Hello", "In Your Eyes", "Style", "The Scientist");

            AddFavoritesBySongName(alex, "Believer", "HUMBLE.", "Clocks", "Levitating");
            AddFavoritesBySongName(sam, "Get Lucky", "Don't Start Now", "Save Your Tears", "R U Mine?");
            AddFavoritesBySongName(priya, "Hello", "Blank Space", "Shake It Off", "bad guy");
            AddFavoritesBySongName(jordan, "DNA.", "LOYALTY.", "Do I Wanna Know?");
            AddFavoritesBySongName(luis, "Instant Crush", "The Scientist", "In My Place", "Physical");
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

        private void AddAlbumWithSongs(
            Artist artist,
            string albumName,
            Genre albumGenre,
            DateOnly albumReleaseDate,
            params (string Name, Genre Genre, int Duration, DateOnly ReleaseDate)[] songs)
        {
            Album album = new Album(albumName, albumGenre, albumReleaseDate, artist);
            AddAlbum(album);

            foreach ((string name, Genre genre, int duration, DateOnly releaseDate) in songs)
            {
                Song song = new Song(name, artist, true, genre, duration, releaseDate);
                album.AddSong(song);
                AddSong(song);
            }
        }

        private void CreatePlaylistWithSongs(User user, string playlistName, params string[] songNames)
        {
            Playlist playlist = user.CreatePlaylist(playlistName);
            foreach (string songName in songNames)
            {
                Song? song = FindSong(songName);
                if (song is not null)
                {
                    playlist.AddSong(song);
                }
            }
        }

        private void AddFavoritesBySongName(User user, params string[] songNames)
        {
            foreach (string songName in songNames)
            {
                Song? song = FindSong(songName);
                if (song is not null)
                {
                    user.AddFavorite(song);
                }
            }
        }
    }
}
