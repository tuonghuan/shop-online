﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class OrderDetailDao
    {
        ShopThoiTrangDbContext db = null;
        public OrderDetailDao()
       {
           db = new ShopThoiTrangDbContext();
       }
       public bool Insert(OrderDetail detail)
       {
           try
           {
               db.OrderDetails.Add(detail);
               db.SaveChanges();
               return true;
           }
           catch
           {
               return false;
           }

       }

    }
}
