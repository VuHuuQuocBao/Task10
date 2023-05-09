namespace Task10_11.DTOs
{
    public class DocumentItemDTOUpdateRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Type { get; set; }

        public int DocumentId { get; set; }
    }
}