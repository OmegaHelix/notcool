using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eIdeas.Models
{
    public class Idea
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string UserID { get; set; }
        public string Title { get; set; }
        public string Problem { get; set; }
        public string Solution { get; set; }
        public string Status { get; set; }
        public string Team { get; set; }

        [Display(Name = "Upload Date")]
        [DataType(DataType.Date)]
        public DateTime UploadDate { get; set; }
    }
}
