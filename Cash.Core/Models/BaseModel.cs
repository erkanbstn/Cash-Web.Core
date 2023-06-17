namespace Cash.Core.Models
{
    public class BaseModel
    {
        // Base Entities

        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
        public bool Status { get; set; } = true;
    }
}
