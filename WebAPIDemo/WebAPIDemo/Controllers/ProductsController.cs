using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    public class ProductsController : ApiController
    {
        public List<Products> GetProductsFromBusinessLayer()
        {
            //List<Products> list = new List<Products>();
            //ProductsBusiness bus = new ProductsBusiness();
            //bus.ShowList();
            //return list;


        }
    }
}
