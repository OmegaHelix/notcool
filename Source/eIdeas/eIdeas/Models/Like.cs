using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eIdeas.Models
{
    public class Like
    {
        [Key]
        public int LikeID { get; set; }
        
        public string UserID { get; set; }

        public bool Liked { get; set; }

        public int IdeaID { get; set; }

    }
}
