using System;

namespace BookStore.Model
{
    public class Banner
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }

        public string Image { get; set; }

        public int WebMenuId { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.Now;

        public DateTime UpdateTime { get; set; } = DateTime.Now;

    }
}