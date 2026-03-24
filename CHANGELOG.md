# Changelog

## Stage 4 - Documentation
- Added `README.md` with architecture, setup, and run instructions.
- Added this `CHANGELOG.md` with stage-by-stage notes.

## Stage 3 - Populate App Data
- Added `SpotifyPlatform.PopulateDemoData()`.
- Seeded artists, albums, songs, users, playlists, and favorites.
- Simplified `Program.cs` to initialize with one population call.

## Stage 2 - Complete the App
- Expanded music domain:
  - `Song`: release date, album link, play/pause, display output.
  - `Album`: add/remove songs, play/pause, computed duration.
  - `Playlist`: add/remove songs, play/pause, computed duration.
- Expanded people domain:
  - `Artist` consistency improvements.
  - `User` with playlist ownership and favorites.
- Added `SpotifyPlatform` to aggregate artists/albums/songs/users.
- Reworked `Program.cs` to demonstrate full functionality.

## Stage 1 - Initial Scaffold
- Original project skeleton and first console flow.
- Initial classes and enum from the first draft structure.
