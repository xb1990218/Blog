using BlogWeb.BllServices.IServices;
using BlogWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlogWeb.BllServices.Services
{
    
    public class BlogService:BaseService<Blog>,IBlogService
    {
        public BlogService(BlogDbContext _blogDbContext)
        {
            db = _blogDbContext;
        }

        public void DelList(int id)
        {
            Blog b=db.Blog.Where(a => a.Id == id).SingleOrDefault();
            if (b!=null)
            {
                db.Entry<Blog>(b).State = EntityState.Deleted;
            }
        }

        public bool SaveChange()
        {
            return  db.SaveChanges()>0;
        }
    }
}
