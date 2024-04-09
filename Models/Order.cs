using System;

namespace WebApplication1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string OrderType { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        public Order()
        {
            Id = 0;
            FullName = "Name";
            PhoneNumber = "1234567890";
            OrderType = "Mmmmm";
            OrderDate = DateTime.Now;
            Status = "OK";
        }
    }
}
