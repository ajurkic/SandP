using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SandP.Models
{
    public class Song
    {
        //Nez zasto, al dodat cu inicijalizaciju liste u konstruktor
        public Song()
        {
            Playlists = new List<Playlist>();
        }

        public int SongId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(128)]
        public string Author { get; set; }

        [Required]
        public int Length { get; set; }

        public ICollection<Playlist> Playlists { get; set; }
    }
}