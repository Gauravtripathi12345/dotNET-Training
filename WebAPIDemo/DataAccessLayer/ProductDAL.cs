using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductDAL // All the CRUD logics in this class
    {
        public List<ProductData> PopulateList()
        {
            SqlConnection cn = new SqlConnection("server=.\\sqlexpress;database=Northwind;Integrated Security=true");
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from products", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<ProductData> list = new List<ProductData>();
            while (dr.Read())
            {
                ProductData p = new ProductData();
                p.Prodid = Convert.ToInt32(dr["ProductID"]);
                p.Prodname = dr["ProductName"].ToString();
                list.Add(p);
            }
            //Connection etc--Model/dbfist/ado.netconnected disconnected

            return list;



        }
    }
}
