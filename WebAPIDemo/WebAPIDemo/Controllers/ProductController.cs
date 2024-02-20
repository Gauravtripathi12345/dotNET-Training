using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    public class ProductController : ApiController 
        // It will contain the logic for calling the Business Logic Layer methods
    {
        public List<ProductModel> GetProductsFromBusinessLayer()
        {
            List<ProductModel> list = new List<ProductModel>();
            ProductBusinessLogicLayer bus = new ProductBusinessLogicLayer();
            List<ProductBusiness> busProducts = bus.ShowList();
            foreach (ProductBusiness prod in busProducts)
            {

                list.Add(new ProductModel { Prodid = prod.Prodid, ProductName = prod.ProductName });
            }
            return list;


        }
    }
}
