using Cash.Core.Models;

namespace Cash.Dto.Dtos.AccountDto
{
    public class AccountAddDto
    {
        public int Id { get; set; }
        public string No { get; set; }
        public int BankId { get; set; }
        public decimal Balance { get; set; }
        public int? UserId { get; set; }
    }
}
