using CarVenture.Dtos;

namespace CarVenture.Models
{
    public class OrderSummaryModel
    {
        public UserResponseDto User { get; set; }
        public CarResponseDto Car { get; set; }
        public OrderRequestDto OrderRequestDto { get; set; }
        public string OrderId { get; set; }
    }
}
