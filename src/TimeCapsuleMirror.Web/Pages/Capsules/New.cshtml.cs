using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TimeCapsuleMirror.Web.Pages.Capsules;

public class NewModel : PageModel
{
    [BindProperty] public string Title { get; set; } = "";
    [BindProperty] public string Body { get; set; } = "";
    [BindProperty] public DateTime UnlockAtLocal { get; set; } = DateTime.Now.AddDays(7);

    public void OnGet() { }

    public IActionResult OnPost()
    {
        // Next step: call Application layer to save into DB
        // For now just redirect to home.
        return RedirectToPage("/Index");
    }
}
