using Cash.Core.Enums;

namespace Cash.Core.Models
{
    public class Bank : BaseModel
    {
        public string Name { get; set; }
        public ExchangeEnum ExchangeType { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
