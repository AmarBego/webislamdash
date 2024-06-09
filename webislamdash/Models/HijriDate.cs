namespace webislamdash.Models
{
    public class HijriDate
    {
        public string Date { get; set; }
        public string Format { get; set; }
        public string Day { get; set; }
        public Month Month { get; set; }
        public string Year { get; set; }
        public Designation Designation { get; set; }
    }

    public class Month
    {
        public int Number { get; set; }
        public string En { get; set; }
        public string Ar { get; set; }
    }
    public class Gregorian
    {
        public string Date { get; set; }
        public string Format { get; set; }
        public string Day { get; set; }
        public Month Month { get; set; }
        public string Year { get; set; }
        public Designation Designation { get; set; }
    }
    public class Designation
    {
        public string Abbreviated { get; set; }
        public string Expanded { get; set; }
    }

    public class ApiResponse
    {
        public int Code { get; set; }
        public string Status { get; set; }
        public List<Day> Data { get; set; }
    }

    public class Day
    {
        public Gregorian Gregorian { get; set; }
        public HijriDate Hijri { get; set; }
    }
}
