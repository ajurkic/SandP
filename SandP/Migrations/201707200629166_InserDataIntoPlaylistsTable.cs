namespace SandP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InserDataIntoPlaylistsTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Playlists(Name) VALUES ('Jazz')");
            Sql("INSERT INTO Playlists(Name) VALUES ('Awesome playlist')");
            Sql("INSERT INTO Playlists(Name) VALUES ('Pop')");
            Sql("INSERT INTO Playlists(Name) VALUES ('Workout')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Playlists WHERE PlaylistId IN (1,2,3,4)");
        }
    }
}
