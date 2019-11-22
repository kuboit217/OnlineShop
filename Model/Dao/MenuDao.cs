using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class MenuDao
    {
        OnlineShopDbContext db = null;
        //tạo kết nối database
        public MenuDao()
        {
            db = new OnlineShopDbContext();
        }
        //hàm lấy thông tin MenuType, Nhóm group Menu
        public List<Menu> ListByGroupId (int groupId)
        {
            return db.Menus.Where(x => x.TypeID == groupId && x.Status == true).OrderBy(x=>x.DisplayOrder).ToList();
        }
    }
}
