using System;

namespace BookStore.Model
{
    public class Contact
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Telephone { get; set; }

        public string FaxNumber { get; set; }

        public string HotLine { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string QQNumber1 { get; set; }
        public string QQNumber2 { get; set; }
        public string WeChat { get; set; }

        public string WeiBo { get; set; }

        public string QRCode { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime UpdateTime { get; set; } = DateTime.Now;
    }
}