using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eIdeas.Models
{
    public class Notification
    {
        public int NotificationID {get; set;}
        public int IdeaID { get; set; }
        public string UserID { get; set; }
        public string Username { get; set; }
        public string NotificationMessage { get; set; }
        public DateTime NotificationDate { get; set; }
    }
}
