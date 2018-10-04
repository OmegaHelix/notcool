using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eIdeas.Models
{
    public class Idea
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Solution { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
