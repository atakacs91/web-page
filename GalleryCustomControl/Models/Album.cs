using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Album
    {
        public string Name { get; set; }

        public string Path { get; set;}

        public List<Image> Images = new List<Image>();
    }
}