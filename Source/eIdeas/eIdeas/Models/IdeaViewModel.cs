using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eIdeas.Models
{
    public class IdeaViewModel
    {
        public Idea idea { get; set; }

        public List<Like> likes { get; set; }

        public List<Comment> comments { get; set; }
    }
}
