using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaserArt.Models
{
    public class Video
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }

        public static List<Video> GetVideos(int? videoId)
        {
            return DAO.VideoDAO.getVideos(videoId);
        }
        public Video Save()
        {
            return DAO.VideoDAO.saveVideo(this);
        }

        public static void Delete(int id)
        {
            DAO.VideoDAO.deleteVideoById(id);
        }
    }
}