using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.Dao
{
    public class SlideDao
    {
        //tạo kết nối database
        OnlineShopDbContext db = null;

        public SlideDao()
        {
            db = new OnlineShopDbContext();
        }
        //đưa ra trang chủ
        public List<Slide> ListAll()
        {
            return db.Slides.Where(x => x.Status == true).OrderBy(x => x.DisplayOrrder).ToList();
        }
        //đưa vào index trang quản trị
        public IEnumerable<Slide> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Slide> model = db.Slides;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Image.Contains(searchString) || x.Link.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        //Thêm bản ghi slideshow
        public long Insert(Slide entity)
        {
            db.Slides.Add(entity);
            db.SaveChanges();

            return entity.ID;
        }

        public Slide ViewDetail(int id)
        {
            return db.Slides.Find(id);
        }

        //update banr ghi trong usser
        public bool Update(Slide entity)
        {
            try
            {
                var slide = db.Slides.Find(entity.ID);

                slide.Image = entity.Image;
                slide.Link = entity.Link;
                slide.DisplayOrrder = entity.DisplayOrrder;
                slide.Status = entity.Status;
                slide.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        //hàm xóa slideshow
        public bool Delete(int id)
        {
            try
            {
                var slide = db.Slides.Find(id);
                db.Slides.Remove(slide);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //hàm changestatus kích hoạt khóa
        public bool ChangeStatus(long id)
        {
            var slide = db.Slides.Find(id);
            slide.Status = !slide.Status;
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;
            return slide.Status;

        }
    }
}
