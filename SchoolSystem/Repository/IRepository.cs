using System.Linq.Expressions;

namespace App.Repos
{
        public interface IRepository<T> where T : class
        {
         IQueryable<T> GetAll();
        T GetById( int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        void Save();

        }

}
