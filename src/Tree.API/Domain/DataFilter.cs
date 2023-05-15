namespace Domain
{
    public class DataFilter
    {
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string Search { get; set; }
    }
}
