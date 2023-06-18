using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cash.Core.Models
{
    public class Account : BaseModel
    {
        public string No { get; set; }
        public string Branch { get; set; }
        public decimal Balance { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public ICollection<Process> ReceiverAcc { get; set; }
        public ICollection<Process> SenderAcc { get; set; }
    }
}
