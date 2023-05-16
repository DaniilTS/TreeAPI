namespace Application.DTO
{
    public class JournalInfoDTO
    {
        public Guid Id { get; set; }

        public string EventId { get; set; }

        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
