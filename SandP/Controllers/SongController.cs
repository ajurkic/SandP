﻿using SandP.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace SandP.Controllers
{
    public class SongController : ApiController
    {
        private readonly SandPContext _context = new SandPContext();

        [Route("api/Song")]
        public IHttpActionResult Get(string searchText)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchText))
                {
                    var songs = _context.Songs.ToList();
                    return Ok(songs);
                }
                else
                {
                    var songs = _context.Songs.Where( song => song.Name.ToLower().Contains( searchText.ToLower() )).ToList();
                    return Ok(songs);
                }
                
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Route("api/Song/{SongId}")]
        public IHttpActionResult Get(int SongId)
        {
            try
            {
                var song = _context.Songs.Find(SongId);
                song.Playlists = _context.Songs.Where(id => id.SongId == SongId)
                                                .Select(p => p.Playlists)
                                                .SingleOrDefault();
                return Ok(song);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Route("api/Song/Save")]
        public IHttpActionResult SaveSong(Song song)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(song.Name))
                    return BadRequest();
                if (string.IsNullOrWhiteSpace(song.Author))
                    return BadRequest();
                if (song.Length < 0)
                    return BadRequest("Duration cannot be negative.");

                _context.Songs.Add(song);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Route("api/Song/Delete/{SongId}")]
        public IHttpActionResult DeleteSong(int SongId)
        {
            try
            {
                _context.Entry(_context.Songs.Find(SongId)).State = EntityState.Deleted;
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Route("api/Song/Update")]
        public IHttpActionResult UpdateSong(Song song)
        {
            try
            {
                var SongFromDb = _context.Songs.Find(song.SongId);
                
                SongFromDb.Name = song.Name;
                SongFromDb.Author = song.Author;
                SongFromDb.Length = song.Length;

                if (string.IsNullOrWhiteSpace(SongFromDb.Name)) return BadRequest();
                if (string.IsNullOrWhiteSpace(SongFromDb.Author)) return BadRequest();
                if (SongFromDb.Length < 0) return BadRequest("Duration cannot be negative.");

                _context.Entry(SongFromDb).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Route("api/Song/AddToPlaylist/{SongId}/{PlaylistId}")]
        public IHttpActionResult AddSongToPlaylist(int SongId, int PlaylistId)
        {
            try
            {
                var playlist = _context.Playlists.Find(PlaylistId);
                var song = _context.Songs.Find(SongId);

                playlist.Songs.Add(song);
                //Don't have to remove it from song.Playlists also because
                //the info comes from the same table in DB

                _context.Entry(playlist).State = EntityState.Modified;
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
