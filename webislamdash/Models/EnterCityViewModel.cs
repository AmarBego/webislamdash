namespace webislamdash.Models
{
    public class EnterCityViewModel
    {
        public string City { get; set; }
    }

    public class CityInfo
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
