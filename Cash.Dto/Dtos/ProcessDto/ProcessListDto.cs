using Cash.Core.Enums;
using Cash.Core.Models;

namespace Cash.Dto.Dtos.ProcessDto
{
    public class ProcessListDto
    {
        public int Id { get; set; }
        public int? ReceiverId { get; set; }
        public int? SenderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Account ReceiverPrc { get; set; }
        public Account SenderPrc { get; set; }
        public User User { get; set; }
        public decimal Amount { get; set; }
        public ProcessEnum Type { get; set; }
    }
}
