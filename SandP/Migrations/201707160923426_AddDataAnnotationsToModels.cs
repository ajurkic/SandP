namespace SandP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotationsToModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Playlists", "Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Songs", "Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Songs", "Author", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Songs", "Author", c => c.String());
            AlterColumn("dbo.Songs", "Name", c => c.String());
            AlterColumn("dbo.Playlists", "Name", c => c.String());
        }
    }
}
