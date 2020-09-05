using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class UserDao
    {
        DBbackendWeb db = null;
        public UserDao()
        {
            db = new DBbackendWeb();
        }
        public long Insert(UserWeb entity)
        {
            db.UserWebs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool update(UserWeb entity)
        {
            try
            {
                var user = db.UserWebs.Find(entity.ID);
                user.Name = entity.Name;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                
                return false;
            }
            
        }
        public IEnumerable<UserWeb> ListAll(string searchString,int page, int pageSize)
        {
            IOrderedQueryable<UserWeb> model = db.UserWebs;
            if(!string.IsNullOrEmpty(searchString))
            {
                model = (IOrderedQueryable<UserWeb>)model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page,pageSize);
        }
        public UserWeb GetbyName(string userName)
        {
            return db.UserWebs.SingleOrDefault(x => x.UserName == userName);
        }
        public UserWeb ViewDetail(int id)
        {
            return db.UserWebs.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.UserWebs.Find(id);
                db.UserWebs.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Longin(string userName, string passWord)
        {
            var result = db.UserWebs.Count(x=> x.UserName == userName && x.Password == passWord);
            if(result>0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
