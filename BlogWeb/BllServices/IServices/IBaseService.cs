using BlogWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWeb.BllServices.IServices
{
   public interface IBaseService<T> where T:class,new()
    {

        //增
         bool Add(T entity);


        //删
         bool Del(T entity);

        //改
        bool Edit(T entity);

        //查
        IQueryable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda);


        //查询分页
        IQueryable<T> GetList<s>(int pageIndex, int pageSize, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, s>> orderbyLambda, bool isAsc);
        
    }
}
