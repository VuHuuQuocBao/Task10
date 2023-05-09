namespace Task10_11.EFCore.DTOs
{
    public class DocumentItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public int DocumentId { get; set; }

        public Document DocumentData { get; set; }
    }
}