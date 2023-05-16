namespace Application.DTO
{
    public class JournalResultDTO
    {
        public int Skip { get; set; }
        public int Count { get; set; }
        public List<JournalDTO> Items { get; set; }
    }
}
