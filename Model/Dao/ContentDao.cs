using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ContentDao
    {
        DBbackendWeb db = null;
        public ContentDao()
        {
            db = new DBbackendWeb();
        }

        public Content GetByID(long id)
        {
            return db.Contents.Find(id);

        }
        public IEnumerable<Content> ListAll(string searchString, int page, int pageSize)
        {
            IOrderedQueryable<Content> model = db.Contents;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = (IOrderedQueryable<Content>)model.Where(x => x.MetaTitle.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public long Insert(Content entity)
        {
            db.Contents.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Delete(int id)
        {
            try
            {
                var content = db.Contents.Find(id);
                db.Contents.Remove(content);
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
