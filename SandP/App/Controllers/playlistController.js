SongsAndPlaylistsApp.controller("playlistController", function ($scope, dataService, $location, $routeParams, $window) {
    // prebaceno u if zbog editanja - $scope.playlists = dataService.getPlaylists();
    $scope.PlaylistId = $routeParams.PlaylistId;

    if ($scope.PlaylistId > 0) {
        $scope.playlist = dataService.getPlaylist($scope.PlaylistId);
    } else {
        $scope.playlists = dataService.getPlaylists();
    }

    $scope.savePlaylist = function () {
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
    }
});