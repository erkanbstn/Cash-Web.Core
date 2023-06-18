using Cash.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cash.Core.Models
{
    public class Process : BaseModel
    {
        public int? ReceiverId { get; set; }
        public int? SenderId { get; set; }
        public Account ReceiverPrc { get; set; }
        public Account SenderPrc { get; set; }
        public decimal Amount { get; set; }
        public ProcessEnum Type { get; set; }
    }
}
