using Cash.Core.Enums;

namespace Cash.Dto.Dtos.ProcessDto
{
    public class ProcessAddDto
    {
        public int Id { get; set; }
        public int? ReceiverId { get; set; }
        public int? SenderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Amount { get; set; }
        public ProcessEnum Type { get; set; }
    }
}
