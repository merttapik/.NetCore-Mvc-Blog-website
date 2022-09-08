using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        public int MessageId { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        //public int? SendersId { get; set; }
        //public int? ReceiversId { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }
        public Writer Sender { get; set; }
        public Writer Receiver { get; set; }
        //public AppUser Senders { get; set; }
        //public AppUser Receivers { get; set; }
    }
}
