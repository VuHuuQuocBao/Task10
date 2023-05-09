namespace Task10_11.DTOs
{
    public class EventDTOUpdateRequest
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public int Day { get; set; }
        public string Desc { get; set; }
        public string Time { get; set; }
    }
}