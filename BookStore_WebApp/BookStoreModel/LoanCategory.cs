using System;

namespace BookStore.Model
{
    public class LoanCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Details { get; set; }

        public string Images { get; set; }

        public int IsShow { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime UpdateTime { get; set; } = DateTime.Now;
    }
}