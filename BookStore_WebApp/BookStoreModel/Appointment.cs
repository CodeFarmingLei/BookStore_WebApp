using System;

namespace BookStore.Model
{
    public class Appointment
    {
        public int Id { get; set; }


        public string RealName { get; set; }

        public string Telephone { get; set; }

        public int Amount { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime UpdateTime { get; set; } = DateTime.Now;
    }
}