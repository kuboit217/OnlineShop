using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CategoryDao
    {
        //tạo kết nối database
        OnlineShopDbContext db = null;

        public CategoryDao()
        {
            db = new OnlineShopDbContext();
        }
        //lấy danh sách category
        public IList<Category> ListAll()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }
    }
}
