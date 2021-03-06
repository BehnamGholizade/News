﻿using LaserArt.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LaserArt.DAO
{
    public class CategoryDAO:DAO
    {
        public static List<Category> getProducts(int? id)
        {

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetCategory", sqlConnection))
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
                        List<Category> newCategoryList = new List<Category>();
                        while (rdr.Read())
                        {
                            Category newCategory = new Category();
                            newCategory.Id = Convert.ToInt32(rdr["Id"]);
                            newCategory.CategoryName = rdr["CategoryName"].ToString();
                            newCategory.CategoryImage = rdr["CategoryImage"].ToString();
                            newCategoryList.Add(newCategory);
                        }
                        return newCategoryList;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }
        }

        public static List<Category> getCategoryByParentId(int? id)
        {

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetCategoryByParentId", sqlConnection))
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
                        List<Category> newCategoryList = new List<Category>();
                        while (rdr.Read())
                        {
                            Category newCategory = new Category();
                            newCategory.Id = Convert.ToInt32(rdr["Id"]);
                            newCategory.CategoryName = rdr["CategoryName"].ToString();
                            newCategory.CategoryImage = rdr["CategoryImage"].ToString();
                            newCategoryList.Add(newCategory);
                        }
                        return newCategoryList;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }
        }
        internal static void DeleteCategoryByID(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_DeleteCategory", sqlConnection))
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

        public static Category saveCategory(Category newCategory)
        {

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_SaveCategory", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (newCategory.Id == null)
                            command.Parameters.AddWithValue("@Id", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Id", newCategory.Id);
                        command.Parameters.AddWithValue("@CategoryName", newCategory.CategoryName);
                        command.Parameters.AddWithValue("@CategoryImage", DBNull.Value);
                        command.Parameters.AddWithValue("@ParentCategoryId", newCategory.ParentCategoryId);

                        command.ExecuteNonQuery();
                        
                        return newCategory;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }
        }

        public static void setCategoryParent(int categoryId,int parentId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_DeleteCategory", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CategoryId", categoryId);
                        command.Parameters.AddWithValue("@ParentId", parentId);

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