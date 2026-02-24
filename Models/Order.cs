using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObuvnoyWPF.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int OrderItemId { get; set; }
        public OrderItem? OrderItem { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public DateTime? DeliveryDate { get; set; }

        public required int PickUpPointId { get; set; }
        public PickUpPoint? PickUpPoint { get; set; }

        public required int UserId { get; set; }
        public User? User { get; set; }

        public required string OrderCode { get; set; }
        public required int OrderStatusId { get; set; }
        public OrderStatus? OrderStatus { get; set; }
    }
}
