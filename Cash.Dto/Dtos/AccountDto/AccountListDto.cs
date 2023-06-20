using Cash.Core.Models;

namespace Cash.Dto.Dtos.AccountDto
{
    public class AccountListDto
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
