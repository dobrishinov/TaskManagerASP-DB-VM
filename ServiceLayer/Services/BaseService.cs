namespace ServiceLayer.Services
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public abstract class BaseService<T> where T : BaseEntity, new()
    {
        protected abstract BaseRepository<T> GenerateService();

        private BaseRepository<T> repostory;

        public BaseService()
        {
            repostory = GenerateService();
        }

        public List<T> GetAll(Expression<Func<T, Boolean>> expr = null, int page = 0, int pageSize = 0)
        {
            return repostory.GetAll(expr,page,pageSize).ToList();
        }

        public T GetById(object id)
        {
            return repostory.GetById(id);
        }

        public int Count(Expression<Func<T, Boolean>> expr = null)
        {
            return repostory.Count(expr);
        }

        public void Delete(T entity)
        {
            repostory.Delete(entity);
        }

        public void Save(T entity)
        {
            repostory.Save(entity);
        }
    }
}
