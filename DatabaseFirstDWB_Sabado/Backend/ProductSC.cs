using DatabaseFirstDWB_Sabado.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDWB_Sabado.Backend
{
    public class ProductSC :  BaseSC
    {

        public void AddNewProduct(string productName, decimal unitPrice)
        {
            var newProduct = new Product();
            newProduct.ProductName = productName;
            newProduct.UnitPrice = unitPrice;

            dataContext.Products.Add(newProduct);
            dataContext.SaveChanges();
        }


    }
}
