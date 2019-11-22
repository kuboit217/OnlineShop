using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ContentDao
    {
        //tạo kết nối database
        OnlineShopDbContext db = null;

        public ContentDao()
        {
            db = new OnlineShopDbContext();
        }
        //lấy ra ID contetn để edit và delete
        public Content GetById(long id)
        {
            return db.Contents.Find(id);
        }
    }
}
