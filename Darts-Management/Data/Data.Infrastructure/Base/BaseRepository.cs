using Darts.Data.Infrastructure;
using Darts.Data.Model.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Data.Infrastructure.Base
{
    public class BaseRepository<T> where T : DAO
    {
        protected Context context;

        public BaseRepository()
        {
            context = GlobalVariables.GetContext();
        }


        public virtual int Speichern(T entity)
        {

            if (entity.ID == 0)
            {
                context.Set<T>().Add(entity);
            }
            else
            {
                T NewEntity = context.Set<T>().Find(entity.ID);
                context.Entry(NewEntity).CurrentValues.SetValues(entity);
            }

            return context.SaveChanges();
        }

        public virtual IList<T> LadeAlle()
        {
            return  context.Set<T>().OrderByDescending(o => o.ID).ToList();
        }

        public virtual int Entfernen(int id)
        {
            context.Set<T>().Remove(context.Set<T>().Find(id));
            return context.SaveChanges();
        }

        public virtual int Entfernen(T t)
        {
            context.Set<T>().Remove(t);
            return context.SaveChanges();
        }

        public virtual T LadeByID(int id)
        {
            return context.Set<T>().Where(a => a.ID == id).First();
        }
    }

    public class BaseRepository
    {
        protected Context context;

        public BaseRepository()
        {
            context = GlobalVariables.GetContext();
        }
    }
}
