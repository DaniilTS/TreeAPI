namespace Domain.Entities
{
    public class Journal
    {
        public Guid Id { get; set; }

        public string EventId { get; set; }

        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}