using SandP.Models;
using System;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;

namespace SandP.Controllers
{
    public class PlaylistController : ApiController
    {
        private readonly SandPContext _context = new SandPContext();

        [Route("api/Playlist")]
        public IHttpActionResult Get(string searchText)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchText))
                {
                    var playlists = _context.Playlists.ToList();
                    return Ok(playlists);
                }
                else
                {
                    var playlists = _context.Playlists.Where(playlist => playlist.Name.ToLower().Contains(searchText.ToLower())).ToList();
                    return Ok(playlists);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Route("api/Playlist/{PlaylistId}")]
        public IHttpActionResult Get(int PlaylistId)
        {
            try
            {
                var playlist = _context.Playlists.Find(PlaylistId);
                playlist.Songs = _context.Playlists.Where(i => i.PlaylistId == PlaylistId)
                                                            .Select(s => s.Songs)
                                                            .SingleOrDefault();
                return Ok(playlist);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Route("api/Playlist/Save")]
        public IHttpActionResult SavePlaylist(Playlist playlist)
        {
            try
            {
                _context.Playlists.Add(playlist);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Route("api/Playlist/Delete/{PlaylistId}")]
        public IHttpActionResult DeletePlaylist(int PlaylistId)
        {
            try
            {
                _context.Entry(_context.Playlists.Find(PlaylistId)).State = EntityState.Deleted;
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Route("api/Playlist/Update")]
        public IHttpActionResult UpdatePlaylist(Playlist playlist) {
            try
            {
                var PlaylistFromDb = _context.Playlists.Find(playlist.PlaylistId);

                PlaylistFromDb.Name = playlist.Name;

                _context.Entry(PlaylistFromDb).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Route("api/Playlist/RemoveSong/{SongId}/{PlaylistId}")]
        public IHttpActionResult RemoveSongFromPlaylist(int SongId, int PlaylistId)
        {
            try
            {
                var playlist = _context.Playlists.Include("Songs").FirstOrDefault(x => x.PlaylistId == PlaylistId);
                var songToRemove = _context.Songs.Find(SongId);
                
                playlist.Songs.Remove(songToRemove);

                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
