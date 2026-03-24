# Spotify InspirationLab

Console-based C# project that models core Spotify concepts:
- songs
- albums
- artists
- users
- playlists
- favorites

The app includes domain classes, platform-level aggregation, and seeded demo data so it can be run immediately.

## Tech Stack
- .NET 9 (`net9.0`)
- C#

## Project Structure
- `SpotifyApp/Music.cs`: `Song`, `Album`, `Playlist`, `Genre`
- `SpotifyApp/People.cs`: `Artist`, `User`
- `SpotifyApp/SpotifyPlatform.cs`: central platform registry + demo data population
- `SpotifyApp/Program.cs`: app entrypoint and demo output
- `structure.txt`: original feature outline/spec

## Run Locally
```bash
dotnet build " Spotify_InspirationLab.sln"
dotnet run --project SpotifyApp/SpotifyApp.csproj
```

## Seeded Demo Dataset
`SpotifyPlatform.PopulateDemoData()` initializes:
- 10 artists
- 10 albums
- 30 songs
- 5 users
- 10 playlists
- favorites per user

## Change Stages
This repository history is intentionally split into development stages.

1. **Initial scaffold**
   - Base console app with early `Artist`, `Album`, `Song` classes and minimal demo.
2. **Core app completion**
   - Full domain behavior (`play`, `pause`, add/remove), `User`, `Playlist`, and `SpotifyPlatform`.
3. **Population stage**
   - Centralized seed generator with richer catalog and simplified startup initialization.
4. **Documentation stage**
   - Project and timeline documentation.

See `CHANGELOG.md` for detailed stage notes.
