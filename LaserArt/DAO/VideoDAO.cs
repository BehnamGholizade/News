using LaserArt.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LaserArt.DAO
{
    public class VideoDAO: DAO
    {
        public static List<Video> getVideos(int? id)
        {

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetVideos", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (id == null)
                            command.Parameters.AddWithValue("@Id", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Id", id);
                        SqlDataReader rdr = command.ExecuteReader();
                        List<Video> videoList = new List<Video>();
                        while (rdr.Read())
                        {
                            Video video = new Video();
                            video.Id = Convert.ToInt32(rdr["Id"]);
                            video.Name = rdr["Name"].ToString();
                            video.Link = rdr["Link"].ToString();

                            //  newCategory.ImageSource = rdr["ImageSource"].ToString();

                            videoList.Add(video);
                        }
                        return videoList;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }
        }

        public static Video saveVideo(Video newVideo)
        {

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_SaveVideo", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (newVideo.Id == null)
                            command.Parameters.AddWithValue("@Id", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Id", newVideo.Id);
                        command.Parameters.AddWithValue("@Name", newVideo.Name);
                        command.Parameters.AddWithValue("@Link", newVideo.Link);

                        command.ExecuteNonQuery();

                        return newVideo;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }
        }

        internal static void deleteVideoById(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_DeleteVideo", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }
        }
    }
}