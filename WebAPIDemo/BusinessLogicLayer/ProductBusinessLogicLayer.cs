using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ProductBusinessLogicLayer // It will consist of all methods which will be invoking the DAL methods.
    {
        public List<ProductBusiness> ShowList()
        {

            List<ProductBusiness> blist = new List<ProductBusiness>();
            ProductDAL dal = new ProductDAL();
            List<DataAccessLayer.ProductData> pDal = new List<DataAccessLayer.ProductData>();
            pDal = dal.PopulateList();
            foreach (var item in pDal)
            {
                ProductBusiness productsBusiness = new ProductBusiness();
                productsBusiness.Prodid = item.Prodid;
                productsBusiness.ProductName = item.Prodname;
                blist.Add(productsBusiness);
            }
            return blist;
        }
    }
}
