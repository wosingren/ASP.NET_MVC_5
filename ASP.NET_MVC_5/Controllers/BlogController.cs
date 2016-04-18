using ASP.NET_MVC_5.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ASP.NET_MVC_5.Controllers
{
    public class BlogController : Controller
    {
        private Blog[] blogs = { 
                new Blog { Id =1, Name ="xpy0928 1",Category=Category.C,BlogAddress="http://www.cnblogs.com/CreateMyself/", Description ="出生非贫即贵，你我无能为力"},
                new Blog { Id =2, Name ="xpy0928 2", Category=Category.Java,BlogAddress="http://www.cnblogs.com/CreateMyself/",Description ="后天若不加以努力赶之超之，又能怪谁呢！"},
                new Blog { Id =3, Name ="xpy0928 3",Category=Category.JavaScript,BlogAddress="http://www.cnblogs.com/CreateMyself/", Description ="自己都靠不住不靠谱，又能靠谁呢！" },
                new Blog { Id =4, Name ="xpy0928 4",Category=Category.SQLServer, BlogAddress="http://www.cnblogs.com/CreateMyself/",Description ="靠自己！"}
                               };
        public ActionResult Index()
        {
            return View();
        }


        private IEnumerable<Blog> GetBlog(string selectedCategory)
        {
            IEnumerable<Blog> data = blogs;
            if (selectedCategory != "All")
            {
                Category selected = (Category)Enum.Parse(typeof(Category), selectedCategory);
                data = blogs.Where(p => p.Category == selected);
            }
            return data;
        }

        public JsonResult GetBlogDataJson(string selectedCategory = "All")
        {
            var data = GetBlog(selectedCategory).Select(b => new
            {
                ID = b.Id,
                Name = b.Name,
                BlogAddress = b.BlogAddress,
                Description = b.Description,
                Category = Enum.GetName(typeof(Category), b.Category)
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetBlogData(string selectedCategory = "All")
        {
            IEnumerable<Blog> data = blogs;
            if (selectedCategory != "All")
            {
                Category selected = (Category)Enum.Parse(typeof(Category), selectedCategory);
                data = blogs.Where(p => p.Category == selected);
            }
            return PartialView(data);
        }

        public ActionResult GetBlogs(string selectedCategory = "All")
        {
            return View((object)selectedCategory);
        }

        //    public ActionResult GetBlogs()
        //    {
        //        return View(blogs);
        //    }

        //    [HttpPost]
        //    public ActionResult GetBlogs(string selectedCategory)
        //    {
        //        if (selectedCategory == null || selectedCategory == "All")
        //        {
        //            return View(blogs);
        //        }
        //        else
        //        {
        //            Category selected = (Category)Enum.Parse(typeof(Category), selectedCategory);
        //            return View(blogs.Where(p => p.Category == selected));
        //        }
        //    }
        //}
    }

}