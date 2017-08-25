namespace SandP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        PlaylistId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PlaylistId);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        SongId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Author = c.String(),
                        Length = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SongId);
            
            CreateTable(
                "dbo.SongPlaylists",
                c => new
                    {
                        Song_SongId = c.Int(nullable: false),
                        Playlist_PlaylistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Song_SongId, t.Playlist_PlaylistId })
                .ForeignKey("dbo.Songs", t => t.Song_SongId, cascadeDelete: true)
                .ForeignKey("dbo.Playlists", t => t.Playlist_PlaylistId, cascadeDelete: true)
                .Index(t => t.Song_SongId)
                .Index(t => t.Playlist_PlaylistId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SongPlaylists", "Playlist_PlaylistId", "dbo.Playlists");
            DropForeignKey("dbo.SongPlaylists", "Song_SongId", "dbo.Songs");
            DropIndex("dbo.SongPlaylists", new[] { "Playlist_PlaylistId" });
            DropIndex("dbo.SongPlaylists", new[] { "Song_SongId" });
            DropTable("dbo.SongPlaylists");
            DropTable("dbo.Songs");
            DropTable("dbo.Playlists");
        }
    }
}
