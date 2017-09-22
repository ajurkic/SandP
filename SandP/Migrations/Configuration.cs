namespace SandP.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SandP.Models.SandPContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SandP.Models.SandPContext context)
        {
            //My comment: This method is called when database is created
            context.Songs.AddOrUpdate(new Models.Song { Name = "Fly me to the moon", Author = "Frank Sinatra", Length = 180 });
            context.Songs.AddOrUpdate(new Models.Song { Name = "My heart will go on", Author = "Celine Dion", Length = 240 });

            context.Playlists.AddOrUpdate(new Models.Playlist { Name = "Old stuff" });
            context.Playlists.AddOrUpdate(new Models.Playlist { Name = "Chill" });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
