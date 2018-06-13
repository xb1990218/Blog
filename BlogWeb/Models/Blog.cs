﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWeb.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Body_md { get; set; }
        public int VisitNum { get; set; }
        public string CaBh { get; set; }
        public string CaName { get; set; }
        public string Remark { get; set; }
        public int Sort { get; set; }
    }
}
