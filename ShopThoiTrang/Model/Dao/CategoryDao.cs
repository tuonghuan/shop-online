using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
   public class CategoryDao
    {
       ShopThoiTrangDbContext db = null;
       public CategoryDao()
       {
           db = new ShopThoiTrangDbContext();
       }
       public List<Category>ListAll()
       {
           return db.Categories.Where(x => x.Status == true).ToList();
       }
       public ProductCategory ViewDetail(long id)
       {
           return db.ProductCategories.Find(id);

       }
    }
}
