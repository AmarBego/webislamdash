using Microsoft.Data.SqlClient.DataClassification;

namespace webislamdash.Models
{
    public class Prayer
    {
        public int PrayerId { get; set; }
        public string PrayerName { get; set; } = default!;
        public string PrayerTime { get; set; } = default!;
        public string PrayerDate { get; set; } = default!;
        public string PrayerLocation { get; set; } = default!;
    }
}
