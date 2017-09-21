SongsAndPlaylistsApp.controller("playlistController", function ($scope, dataService, $location, $routeParams) {
    // switched to if because of editing - $scope.playlists = dataService.getPlaylists();
    $scope.PlaylistId = $routeParams.PlaylistId;

    if ($scope.PlaylistId > 0) {
        $scope.playlist = dataService.getPlaylist($scope.PlaylistId);
    } else {
        $scope.playlists = dataService.getPlaylists();
    }

    $scope.searchPlaylist = function () {
        $scope.playlists = dataService.getPlaylists($scope.searchText);
        $scope.tableVisibility = true;
    };

    $scope.savePlaylist = function (valid) {
        if (valid) {
            if ($scope.playlist.PlaylistId > 0) {
                dataService.updatePlaylist($scope.playlist).$promise.then(
                    function () {
                        $location.path('#!/');
                    },
                    function () {
                        alert("Updating playlist went wrong");
                    });
            } else {
                dataService.savePlaylist($scope.playlist).$promise.then(
                function () {
                    $location.path('#!/');
                },
                function () {
                    alert("Saving playlist failed!");
                });
            }
        } else {
            alert("Please check the playlist name.");
        }
    };

    $scope.deletePlaylist = function (PlaylistId) {
        if (confirm("Do you really want to delete this playlist?")) {
            dataService.deletePlaylist(PlaylistId).$promise.then(
               function () {
                   $location.path("#!/");
               }, function () {
                   alert("Deleting playlist failed. Please contact support at admin@mail.com");
               });
        }
    };

    $scope.removeSongFromPlaylist = function (SongId, PlaylistId) {
        dataService.removeSongFromPlaylist(SongId, PlaylistId).$promise.then(
            function () {
                $location.path("#/!");
            },
            function () {
                alert("Deleting song from playlist failed. Please contact support at admin@mail.com");
            });
    };

    $scope.addSongToPlaylist = function () {
        /*
        Don't have to send anything from form, can reach everything with scope :)
        */
        dataService.addSongToPlaylist($scope.SongId, $scope.PlaylistId).$promise.then(
            function () {
                $location.path("#!/Song/Update/" + $scope.PlaylistId);
            },
            function () {
                alert("Something went wrong with adding the song to playlist.");
            });
        }
});