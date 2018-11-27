using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eIdeas.Models
{
    public class Subscribe
    {
        [Key]
        public int SubscriptionID { get; set; }

        public string UserID { get; set; }

        public bool Subscribed { get; set; }

        public int IdeaID { get; set; }

    }
}
