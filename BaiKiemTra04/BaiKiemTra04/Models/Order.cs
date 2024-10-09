using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra04.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        public string OrderName { get; set; }

        public DateTime OrderDate { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        [Required]
        public string OrderStatus { get; set; }
    }
}