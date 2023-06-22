using Cash.Core.Models;

namespace Cash.Dto.Dtos.AccountDto
{
    public class AccountListDto
    {
        public int Id { get; set; }
        public string No { get; set; }
        public decimal Balance { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Bank Bank { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Process> ReceiverAcc { get; set; }
        public ICollection<Process> SenderAcc { get; set; }
    }
}
