var SongsAndPlaylistsApp = angular.module("SongsAndPlaylistsApp", ["ngRoute", "ngResource"]);

SongsAndPlaylistsApp.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "/App/Views/IndexView.html",
            controller: "songController"
        })
        .when("/Song/Add", {
            templateUrl: "/App/Views/AddOrEditSong.html",
            controller: "songController"
        })
        .when("/Song/Update/:SongId", {
            templateUrl: "/App/Views/AddOrEditSong.html",
            controller: "songController"
        })
        .when("/Playlist/Add", {
            templateUrl: "/App/Views/AddOrEditPlaylist.html",
            controller: "playlistController"
        })
        .when("/Playlist/Update/:PlaylistId", {
            templateUrl: "/App/Views/AddOrEditPlaylist.html",
            controller: "playlistController"
        })
        .otherwise({ redirectTo: "/" });
});

SongsAndPlaylistsApp.filter('songFilter', function () {
    return function (collection, song) {
        var output = [];
        angular.forEach(collection, function (item) {
            if (song.indexOf(item) == -1) {
                output.push(item);
            }
        })
        return output;
    }
});