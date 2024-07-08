using System.ComponentModel.DataAnnotations;

namespace QanShopWebApi.Models.ViewModels
{
    public class CreateCartClass
    {
        [Required]
        [Range(1, 10,ErrorMessage = "Số lượng tối thiểu là 1 và tối đa là 10")]
        public int Quantity { get; set; } = 1;
        [Required(ErrorMessage = "Vui Lòng Chọn Sản Phẩm")]
        public Guid ProductId { get; set; }
    }
}
