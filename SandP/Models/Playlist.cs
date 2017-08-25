using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SandP.Models
{
    public class Playlist
    {
        //Nez zasto, al dodat cu inicijalizaciju liste u konstruktor
        public Playlist()
        {
            Songs = new List<Song>();
        }

        public int PlaylistId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}