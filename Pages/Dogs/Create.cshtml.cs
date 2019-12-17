using System.Threading.Tasks;
using DogShelter.Data;
using DogShelter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DogShelter.Pages.Dogs
{
    public class CreateModel : PageModel
    {
        private readonly ShelterContext _context;

        public CreateModel(ShelterContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] public Dog Dog { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyDog = new Dog();
            if (await TryUpdateModelAsync<Dog>(emptyDog, "dog",
                d => d.Name, d => d.Breed, d => d.Sex, d => d.Summary, d => d.ImageUrl, d => d.Adoptions))

                if (!ModelState.IsValid)
                {
                    return Page();
                }

            _context.Dogs.Add(emptyDog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}