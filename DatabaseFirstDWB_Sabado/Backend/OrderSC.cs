using DatabaseFirstDWB_Sabado.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDWB_Sabado.Backend
{
    public class OrderSC : BaseSC
    {

        public IQueryable<Order> GetOrderByID(int orderID)
        {
            return GetAllOrders().Where(w => w.OrderId == orderID);
        }

        public IQueryable<Order> GetAllOrders()
        {
            return dataContext.Orders;
        }

    }
}
