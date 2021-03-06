﻿using LaserArt.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LaserArt.Models
{
    public class Product
    {
        public int? Id { get; set; }
        [Required]
        public string ProductTitle { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal PriceDiscounted { get; set; }
        [Required]
        public string ImageSource { get; set; }

        public string VideoSource { get; set; }


        public string ImageSource1 { get; set; }
        public string ImageSource2 { get; set; }
        public string ImageSource3 { get; set; }
        public bool isSlide { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public Product SaveProduct()
        {
            return ProductDAO.saveProduct(this);
        }

        public static List<Product> GetProducts(int? id)
        {
            return ProductDAO.getProducts(id);
        }
        public static void DeleteProduct(int id)
        {
             ProductDAO.deleteProduct(id);
        }
        public static List<Product> GetProductsByCategoryId(int categoryId)
        {
            return ProductDAO.getProductsByCategoryId(categoryId);
        }

        internal static List<Product> GetSlides()
        {
            return ProductDAO.getSlides();
        }

        public static List<Product> GetProductsByQuery(string query)
        {
            return ProductDAO.getProductsByQuery(query);
        }
        public static Dictionary<int,Product> GetProductsByOrderId(int orderId)
        {
            return ProductDAO.getProductsByOrderId(orderId);
        }
        public void SaveView()
        {
            ProductDAO.saveView(Convert.ToInt32(this.Id));
        }

        public static int GetViews(int id)
        {
            return ProductDAO.getView(id);
        }
    }
}