using BlogWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWeb.BllServices.IServices
{
    public interface IBlogService:IBaseService<Blog>
    {
        void DelList(int id);
        bool SaveChange();
    }
}
