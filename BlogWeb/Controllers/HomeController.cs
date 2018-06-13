using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogWeb.Models;
using BlogWeb.BllServices.IServices;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace BlogWeb.Controllers
{
    public class HomeController : Controller
    {
        private IBlogService blogService;
        public HomeController(IBlogService _blogService)
        {
            blogService = _blogService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        //获取文章列表 分页
        public JsonResult GetList()
        {
            int page =int.Parse( Request.Form["page"]);
            int pageIndex= int.Parse(Request.Form["rows"]);
            int totalCount;
            List<Blog> list = blogService.GetList(page, pageIndex, out totalCount, a => true, a => a.Id, false).ToList();
            return Json(new { rows=list,total= totalCount });
        }

        //增加文章
        public string Add(Blog blog)
        {
                blog.CreateDate = DateTime.Now;
            if (blogService.Add(blog))
            {
                return "ok";
            }
            else
            {
                return "no";
            }

        }

        //编辑
        public string Edit(Blog blog)
        {
            Blog m=blogService.Get(a => a.Id == blog.Id).FirstOrDefault();
            if (m!=null)
            {
                m.Title = blog.Title;
                m.Body = blog.Body;
                m.CaBh = blog.CaBh;
                m.Remark = blog.Remark;
                m.VisitNum = blog.VisitNum;
                if (blogService.Edit(m))
                {
                    return "ok";
                }
            }
            return "no";
        }

        public string DelList(string ids)
        {
            string[] arry = ids.Split('|');
            foreach (string s in arry)
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    int i = int.Parse(s);
                    blogService.DelList(i);
                }
            }
            bool b=blogService.SaveChange();
            if (b)
            {
                return "ok";
            }
            else
            {
                return "no";
            }
            
        }

    }
}
