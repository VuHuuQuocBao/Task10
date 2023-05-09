namespace Task10_11.EFCore.DTOs
{
    public class Document
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<DocumentItem> documentItemDatas { get; set; }

        public Document()
        {
            documentItemDatas = new List<DocumentItem>();
        }
    }
}