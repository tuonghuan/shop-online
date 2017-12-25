using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
   public class ContactDao
    {
        ShopThoiTrangDbContext db = null;
        public ContactDao()
       {
           db = new ShopThoiTrangDbContext();
       }
       public Contact GetActiveContact()
        {
            return db.Contacts.Single(x => x.Status == true);
        }
       public int InsertFeedBack(FeedBack fb)
       {
           db.FeedBacks.Add(fb);
           db.SaveChanges();
           return fb.ID;
       }
    }
}
