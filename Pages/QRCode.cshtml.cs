using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project334.Pages
{
    public class QRCodeModel : PageModel
    {
        [BindProperty]
        public string link { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
        }
    }
}
