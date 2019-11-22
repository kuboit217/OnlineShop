using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace Model.Dao
{
    public class UserDao
    {
        OnlineShopDbContext db = null;
        //tạo kết nối database
        public UserDao()
        {
            db = new OnlineShopDbContext();
        }
        //lấy danh sách bản ghi trong user
        public IEnumerable<User> ListAllPaging(string searchString, int page,int pageSize)
        {
            IQueryable<User> model = db.Users;
            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page,pageSize);
        }
        //Thêm bản ghi username
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();

            return entity.ID;
        }
        //lấy thông tin bằng ID
        public User GetById(string userName)
        {
            //lấy ra 1 bản ghi bằng userName
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        //tìm kiếm thông tin qua ID
        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }
        //update banr ghi trong usser
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                //kiểm tra password không rỗng thì mới gắn
                if(!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                    user.ConfirmPassword = entity.Password;
                }                
                user.Name = entity.Name;
                user.Email = entity.Email;
                user.Phone = entity.Phone;
                user.Address = entity.Address;
                user.ModifiedBy = user.ModifiedBy;
                user.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
        //hàm xóa thông tin user
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Kiểm tra đăng nhập
        public int Login(string userName, string passWord)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName );
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                    return -1;
                else
                {
                    if (result.Password == passWord)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }
        //hàm changestatus kích hoạt khóa
        public bool ChangeStatus(long id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;
            return user.Status;

        }
    }
}
