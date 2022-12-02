using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Domain.Entities
{
    public class Message
    {
        public int Message_Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Member_Id { get; set; }
    }
}
