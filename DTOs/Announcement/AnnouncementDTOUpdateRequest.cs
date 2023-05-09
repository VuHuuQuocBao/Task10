namespace Task10_11.DTOs
{
    public class AnnouncementDTOUpdateRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? linkImage { get; set; }
        public string Desc { get; set; }
        public string Date { get; set; }
        public string Text { get; set; }
    }
}