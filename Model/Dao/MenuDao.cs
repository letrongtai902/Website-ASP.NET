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
        DBbackendWeb db = null;
        public MenuDao()
        {
            db = new DBbackendWeb();
        }
        public List<Menu> ListByID(int typeid)
        {
            return db.Menus.Where(x => x.TypeID == typeid).ToList();
        }
        public long Insert(Menu entity)
        {
            db.Menus.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Delete(int id)
        {
            try
            {
                var menu = db.Menus.Find(id);
                db.Menus.Remove(menu);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
