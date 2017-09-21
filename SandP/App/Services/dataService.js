SongsAndPlaylistsApp.factory("dataService", function($resource) {
    var _getSongs = function (searchText) {
        return $resource('api/Song').query({ searchText: searchText ? searchText : '' });
    };
    var _getSong = function (SongId) {
        return $resource('api/Song/:SongId', { SongId: '@SongId' }).get({ SongId: SongId });
    };
    var _saveSong = function (song) {
        return $resource('api/Song/Save').save(song);
    };
    var _deleteSong = function (SongId) {
        return $resource('api/Song/Delete/:SongId', { SongId: '@SongId' }).delete({ SongId: SongId });
    };
    var _updateSong = function (song) {
        return $resource('api/Song/Update').save(song);
    };
    var _addSongToPlaylist = function (SongId, PlaylistId) {
        return $resource('api/Song/AddToPlaylist/:SongId/:PlaylistId', { SongId: '@SongId', PlaylistId: '@PlaylistId' }).save({ SongId: SongId, PlaylistId: PlaylistId });
    };

    /*---------------------------------------------*/

    var _getPlaylists = function (searchText) {
        return $resource('api/Playlist').query({ searchText: searchText ? searchText : '' });
    };
    var _getPlaylist = function (PlaylistId) {
        return $resource('api/Playlist/:PlaylistId', { PlaylistId: '@PlaylistId' }).get({PlaylistId: PlaylistId});
    };
    var _savePlaylist = function (playlist) {
        return $resource('api/Playlist/Save').save(playlist);
    };
    var _deletePlaylist = function (PlaylistId) {
        return $resource('api/Playlist/Delete/:PlaylistId', { PlaylistId: '@PlaylistId' }).delete({ PlaylistId: PlaylistId });
    };
    var _updatePlaylist = function (playlist) {
        return $resource('api/Playlist/Update').save(playlist);
    };

    var _removeSongFromPlaylist = function (SongId, PlaylistId) {
        return $resource('api/Playlist/RemoveSong/:SongId/:PlaylistId', { SongId: '@SongId', PlaylistId: '@PlaylistId' }).save({ SongId: SongId, PlaylistId: PlaylistId });
    };

    return {
        getSongs: _getSongs,
        getSong: _getSong,
        saveSong: _saveSong,
        deleteSong: _deleteSong,
        updateSong: _updateSong,
        addSongToPlaylist: _addSongToPlaylist,
        getPlaylists: _getPlaylists,
        getPlaylist: _getPlaylist,
        savePlaylist: _savePlaylist,
        deletePlaylist: _deletePlaylist,
        updatePlaylist: _updatePlaylist,
        removeSongFromPlaylist: _removeSongFromPlaylist
    }
});