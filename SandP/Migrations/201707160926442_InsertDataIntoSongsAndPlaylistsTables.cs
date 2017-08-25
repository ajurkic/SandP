namespace SandP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertDataIntoSongsAndPlaylistsTables : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Songs(Name, Author, Length) VALUES ('Something like this', 'Coldplay', 250)");
            Sql("INSERT INTO Songs(Name, Author, Length) VALUES ('Little talks', 'Of Monsters And Men', 212)");
            Sql("INSERT INTO Songs(Name, Author, Length) VALUES ('Four seasons', 'Antonio Vivaldi', 500)");
            Sql("INSERT INTO Songs(Name, Author, Length) VALUES ('With everything', 'Hillsong United', 302)");
            Sql("INSERT INTO Songs(Name, Author, Length) VALUES ('Fur Elise', 'Ludwig van Beethoven', 174)");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Songs WHERE SongID IN (1,2,3,4,5)");
        }
    }
}
