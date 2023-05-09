using Microsoft.EntityFrameworkCore;

namespace Task10_11.EFCore.DTOs
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? linkImage { get; set; }
        public string Desc { get; set; }
        public string Date { get; set; }
        public string Text { get; set; }
    }
}