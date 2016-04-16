using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_MVC_5.Models
{
    public class Blog
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string BlogAddress { get; set; }

        public string Description { get; set; }

        public Category Category;

    }

    public enum Category
    {
        C,
        Java,
        JavaScript,
        SQLServer
    }
}