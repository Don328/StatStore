using Microsoft.EntityFrameworkCore;
using StatStore.Loader.Core.Data.Interfaces;

namespace StatStore.Loader.Core.Data
{
    public class DbRepo<T> : IGenericDataRepo<T> where T : class
    {
        private readonly AppDbContext db;
        private DbSet<T> table;

        public DbRepo(AppDbContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T? GetById(int id)
        {
            return (from t in table
                    where (int)t.GetType().GetProperty("Id").GetValue(t) == id
                    select t).FirstOrDefault();
        }

        public T? GetByProperty(string name, object value)
        {
           return (from t in table
                          where t.GetType().GetProperty(name).GetValue(t) == value
                          select t).FirstOrDefault();
        }

        public void Create(T entity)
        {
            table.Add(entity);
            Save();
        }

        public void Delete(T entity)
        {
            int? id = (int?)entity.GetType().GetProperty("Id")?.GetValue(entity);

            if (id > 0)
            {
                var obj = GetById((int)id);
                if (obj != null)
                {
                    table.Remove(obj);
                    Save();
                }
            }
        }

        public void Update(T entity)
        {
            int? id = (int?)entity.GetType().GetProperty("Id")?.GetValue(entity);
            if (id > 0)
            {
                var obj = GetById((int)id);
                if (obj != null)
                {
                    foreach(var prop in obj.GetType().GetProperties())
                    {
                        prop.SetValue(obj, prop.GetValue(entity), null);
                    }

                    Save();
                }
            }

        }

        private void Save()
        {
            db.SaveChanges();
        }
    }
}
