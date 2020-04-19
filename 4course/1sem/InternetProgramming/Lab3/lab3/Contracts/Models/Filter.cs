namespace Contracts.Models
{
    public class Filter
    {
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public bool? IsSort { get; set; }
        public int? MinId { get; set; }
        public int? MaxId { get; set; }
        public string Query { get; set; }
        public bool? IsGlobal { get; set; }  
    }
}
