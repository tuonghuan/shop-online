﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class FooterDao
    {
        ShopThoiTrangDbContext db = null;
        public FooterDao()
       {
           db = new ShopThoiTrangDbContext();
       }
        public Footer GetFooter()
        {
            return db.Footers.SingleOrDefault(x=>x.Status == true);
        }
    }
}
