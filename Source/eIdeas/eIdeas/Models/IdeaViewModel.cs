using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eIdeas.Models
{
    public class IdeaViewModel
    {
        public Idea Idea { get; set; }

        public List<Like> Likes { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
