using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Validation.Models
{
    public class CustomerInfo
    {
        [Display(Name = "Tên khách")]
        [Required(ErrorMessage = "{0} Không được để trống")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} Phải dài từ {2} tới {1} ký tự")]
        [ModelBinder(BinderType = typeof(UserNameBinding))]
        public string CustomerName {get; set;}

        [Display(Name = "Địa chỉ email")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không phù hợp")]
        [Required(ErrorMessage = "{0} Không được để trống")]
        public string Email {get; set;}

        [DisplayName("Năm sinh")]
        [Range(1970, 2000, ErrorMessage = "{0} không hợp lệ, phải trong khoảng {1} đến {2}")]
        [Required(ErrorMessage = "{0} Không được để trống")]
        public int? YearOfBirth {get; set;}
    }
}