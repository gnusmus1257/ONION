﻿using OAA.Data;
using OAA.Service.Interfaces;
using OAA.Service.Service;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace OAA.Cons
{
    public class SearchTrack
    {
        private readonly ITrackService trackService;
        private readonly IAlbumService albumService;
        private readonly IArtistService artistService;

        public SearchTrack(IAlbumService albumService, ITrackService trackService, IArtistService artistService)
        {
            this.trackService = trackService;
            this.albumService = albumService;
            this.artistService = artistService;
        }

        public void Search()
        {
            string[] filenames = Directory.GetFiles("D:/WEB_Onion/OAA.Web/wwwroot/tracks/", "*.mp3", SearchOption.AllDirectories);
            foreach (var link in filenames)
            {
                // nameTrack-nameArtist.mp3
                var nameTrack = "";
                var nameArtist = "";
                var splited = link.Split("-");
                nameTrack = splited[0].Split("/")[5];
                nameArtist = splited[1].Replace(".mp3", "");

                var linkT = "http://localhost:52527/tracks/" + nameTrack + "-" + nameArtist + ".mp3";

                var nameT = nameTrack.Replace(" ", "+");
                var nameA = nameArtist.Replace(" ", "+");

                if (artistService.GetAll().Where(a => a.Name == nameArtist).Count() == 0)
                {
                    AddArtistToDb(nameArtist);
                }

                var nameAlbum = trackService.GetAlbumTrackName(nameA, nameT);
                Album album = albumService.GetAll().Where(a => a.NameArtist == nameArtist).FirstOrDefault(b => b.Name == nameAlbum);

                if (album == null)
                {
                    Album alb = albumService.GetAlbum(nameArtist, nameAlbum);
                    alb.ArtistId = artistService.Get(nameArtist).Id;
                    albumService.Create(alb);
                }

                if (trackService.GetAll().Where(a => a.Name == nameTrack).FirstOrDefault(b => b.NameAlbum == nameAlbum) != null)
                {
                    AddLinkToDb(nameTrack, nameArtist, linkT);
                }
                else
                {
                    Track track = trackService.AddTrackFromLast(nameTrack, nameArtist, linkT);
                    track.AlbumId = albumService.GetAll().Where(a => a.Name == nameAlbum).FirstOrDefault(b => b.NameArtist == nameArtist).Id;
                    track.NameAlbum = nameAlbum;
                    trackService.Create(track);
                }
            }
        }

        public void AddArtistToDb(string name)
        {
            Artist artist = artistService.GetArtist(name);
            artistService.Create(artist);
        }

        public void AddLinkToDb(string nameTrack, string nameArtist, string link)
        {
            string nameT = nameTrack;
            string nameA = nameArtist;
            Track track = albumService.GetAll().FirstOrDefault(a => a.NameArtist == nameArtist).Tracks.FirstOrDefault(t => t.Name == nameTrack);
            track.Link = link;
            trackService.Update(track);
        }
    }
}
