using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eIdeas.Models
{
    public class Comment
    {
        public int CommentID { get; set; }

        public int IdeaID { get; set; }

        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserComment { get; set; }

        [Display(Name = "Upload Date")]
        [DataType(DataType.Date)]
        public DateTime UploadDate { get; set; }
    }
}
