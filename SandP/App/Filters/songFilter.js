SongsAndPlaylistsApp.filter('songFilter', function () {

    //Filter returns all the playlists that are not in the targetPlaylists, but are in playlists
    //playlists - all playlists in database
    //targetPlaylists - all playlists the song is put into
    return function (playlists, targetPlaylists) {
        var i = 0;

        //New song doesn't have selected playlists, because it has to be submitted first
        if (targetPlaylists == undefined)
            return null;

        angular.forEach(targetPlaylists, function (targetPlaylist) {
            angular.forEach(playlists, function (playlist) {
                if (targetPlaylist.PlaylistId == playlist.PlaylistId)
                {
                    var index = playlists.indexOf(playlist);
                    playlists.splice(index, 1);
                }
            });
        });
        return playlists;
    };
});