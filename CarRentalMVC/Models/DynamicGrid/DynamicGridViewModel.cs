namespace CarRentalMVC.Models.DynamicGrid
{
    public class DynamicGridViewModel
    {
        public IEnumerable<object> Data { get; set; }
        public string BaseRoute { get; set; }
    }

}
