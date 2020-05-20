using System;

namespace BookStore.Model
{
    public class Explanation
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int LoanCategoryId { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime UpdateTime { get; set; } = DateTime.Now;
    }
}