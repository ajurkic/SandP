namespace SandP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingSongPlaylistsTableWithWorkingManyToManyRelation1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO SongPlaylists VALUES (1,1)");
            Sql("INSERT INTO SongPlaylists VALUES (1,2)");
            Sql("INSERT INTO SongPlaylists VALUES (1,3)");
            Sql("INSERT INTO SongPlaylists VALUES (2,3)");
            Sql("INSERT INTO SongPlaylists VALUES (3,1)");
            Sql("INSERT INTO SongPlaylists VALUES (3,2)");
            Sql("INSERT INTO SongPlaylists VALUES (3,4)");
            Sql("INSERT INTO SongPlaylists VALUES (4,1)");
            Sql("INSERT INTO SongPlaylists VALUES (4,3)");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM SongPlaylists WHERE Song_SongId IN (1,2,3,4)");
        }
    }
}
