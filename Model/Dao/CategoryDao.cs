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
        DBbackendWeb db = null;
        public CategoryDao()
        {
            db = new DBbackendWeb();
        }
        public List<New> ListALL()
        {
            return db.News.Where(x => x.Status == true).ToList();
        }
    }
}
