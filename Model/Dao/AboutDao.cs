using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class AboutDao
    {
        OnlineShopDbContext db = null;
        //tạo kết nối database
        public AboutDao()
        {
            db = new OnlineShopDbContext();
        }
        //lấy danh sách bản ghi trong user
        public IEnumerable<About> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<About> model = db.Abouts;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Detail.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        //hàm changestatus kích hoạt khóa
        public bool ChangeStatus(long id)
        {
            var about = db.Slides.Find(id);
            about.Status = !about.Status;
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;
            return about.Status;

        }
    }
}
