namespace CarRentalCore.Models
{
    public class Role : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }

}
