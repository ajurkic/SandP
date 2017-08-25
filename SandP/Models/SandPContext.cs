using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SandP.Models;

namespace SandP.Models
{
    public class SandPContext : DbContext
    {
        //Dbset of my models
        public DbSet<Song> Songs { get; set; }
        public DbSet<Playlist> Playlists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>()
                .HasMany(t => t.Playlists)
                .WithMany(t => t.Songs)
                .Map(m =>
                {
                    m.ToTable("SongPlaylists");
                    m.MapLeftKey("Song_SongId");
                    m.MapRightKey("Playlist_PlaylistId");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}