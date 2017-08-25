SongsAndPlaylistsApp.controller("songController", function ($scope, dataService, $location, $routeParams) {
    //$scope.songs = dataService.getSongs() -> prebačeno u else jer sad dohvat pisme gledan po SongId-ju

    $scope.SongId = $routeParams.SongId;

    if ($scope.SongId > 0) {
        $scope.song = dataService.getSong($scope.SongId);
    } else {
        $scope.songs = dataService.getSongs();
    }

    $scope.saveSong = function () {
        if ($scope.song.SongId > 0) {
            dataService.updateSong($scope.song).$promise.then(
                function () {
                    $location.path('#!/');
                },
                function () {
                    alert("Updating the song went wrong!");
                });
        } else {
            dataService.saveSong($scope.song).$promise.then(
                function () {
                    $location.path('#!/');
                },
                function () {
                    alert("Saving the song went wrong!");
                }
            );
        }
    };

    $scope.deleteSong = function (SongId) {
        if (confirm("Do you really want to delete this song?")) {
            dataService.deleteSong(SongId).$promise.then(
               function () {
                $location.path("#!/");
            }, function () {
                alert("Something went wrong");
            });
        }
    };

    $scope.updateSong = function () {
        if ($scope.song.SongId > 0) {
            dataService.updateSong($scope.song).$promise.then(function () {
                $location.path("#!/");
            }, function () {
                alert("Error saving the updated song");
            });
        }
    };

    $scope.addSongToPlaylist = function (playlist) {
        /*
        Sending whole playlist here because it is not in the scope like SongId
        */
        dataService.addSongToPlaylist($scope.SongId, playlist.PlaylistId).$promise.then(
            function () {
                $location.path("#!/Playlist/Update/" + playlist.PlaylistId);
            },
            function () {
                alert("Something went wrong with adding the song to playlist.");
            });
    }
});