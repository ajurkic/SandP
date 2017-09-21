SongsAndPlaylistsApp.controller("songController", function ($scope, dataService, $location, $routeParams) {
    //$scope.songs = dataService.getSongs() -> prebačeno u else jer sad dohvat pisme gledan po SongId-ju

    $scope.SongId = $routeParams.SongId;

    if ($scope.SongId > 0) {
        $scope.song = dataService.getSong($scope.SongId);
    } else {
        $scope.songs = dataService.getSongs();
    }

    $scope.searchSong = function () {
        $scope.songs = dataService.getSongs($scope.searchText);
        $scope.tableVisibility = true;
    };

    $scope.saveSong = function (valid) {

        if (valid)
        {
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
                    });
            }
        } else {
            alert("Please check if you have entered values in all fields correctly.");
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
            dataService.updateSong($scope.song).$promise.then(
                function () {
                $location.path("#!/");
            }, function () {
                alert("Error saving the updated song");
            });
        }
    };
});