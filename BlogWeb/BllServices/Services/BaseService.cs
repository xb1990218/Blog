using BlogWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWeb.BllServices.Services
{
    public class BaseService<T> where T:class,new()
    {
        public BlogDbContext db;

        //增
        public bool Add(T entity)
        {
            db.Set<T>().Add(entity);
            int i = db.SaveChanges();
            if (i > 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        //删
        public bool Del(T entity)
        {
            db.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            return db.SaveChanges()>0;
        }
        //改
        public bool Edit(T entity)
        {
            db.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        //查
        public IQueryable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return db.Set<T>().Where<T>(whereLambda);
        }

        //查询分页
        public IQueryable<T> GetList<s>(int pageIndex, int pageSize, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {
            var temp = db.Set<T>().Where<T>(whereLambda);
            totalCount = temp.Count();
            if (isAsc)//升序
            {
                temp = temp.OrderBy<T, s>(orderbyLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            else
            {
                temp = temp.OrderByDescending<T, s>(orderbyLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            return temp;

        }

    }
}
