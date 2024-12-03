namespace CarRentalService.DTOs
{
    public abstract class BaseModelDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public bool IsActive { get; set; } = true;
    }

}
