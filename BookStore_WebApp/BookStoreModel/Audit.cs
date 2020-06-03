using System;

namespace BookStore.Model
{
    public class Audit
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime UpdateTime { get; set; } = DateTime.Now;
    }
}