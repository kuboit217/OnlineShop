using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductDao
    {
        //tạo kết nối database
        OnlineShopDbContext db = null;

        public ProductDao()
        {
            db = new OnlineShopDbContext();
        }
        //lấy danh sách sản phẩm mới
        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }
        // lấy danh sách sản phẩm hot
        public List<Product> ListFeatureProduct(int top)
        {
            return db.Products.Where(x => x.TopHot != null).OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }
    }
}
