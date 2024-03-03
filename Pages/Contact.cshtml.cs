using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Validation.Models;

namespace Validation.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IWebHostEnvironment _enviroment;
        public ContactModel(IWebHostEnvironment enviroment)
        {
            _enviroment = enviroment;
        }
        [BindProperty]
        public CustomerInfo customerInfo {get; set;}

        [BindProperty]
        [DataType(DataType.Upload)]
        [DisplayName("File upload")]
        public IFormFile FileUpload {get; set;}
        
        public void OnGet()
        {
        }
        public string thongbao {get; set;}
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                // _enviroment.WebRootPath
                // FileUpload.FileName
                thongbao = "Dữ liệu gửi đến phù hợp";
                if (FileUpload != null)
                {
                    var filepath = Path.Combine(_enviroment.WebRootPath, "uploads", FileUpload.FileName);
                    using var filestream = new FileStream(filepath, FileMode.Create);
                    FileUpload.CopyTo(filestream);
                }
            }
            else 
            {
                thongbao = "Dữ liệu gửi đến không phù hợp";
            }
        }
    }
}
