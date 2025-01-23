using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.Entities
{
    public class Message
    {
        public int MessageID { get; set; }
        public int SenderID { get; set; }
        public int? ReceiverID { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }

        // Relaciones de navegación
        public User Sender { get; set; }
        public User Receiver { get; set; }
    }
}
