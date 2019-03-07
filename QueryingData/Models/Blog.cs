﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryingData.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int? Rating { get; set; }


        public int? OwnerId { get; set; }
        public List<Post> Posts { get; set; }
        public Person Owner { get; set; }
    }
}
