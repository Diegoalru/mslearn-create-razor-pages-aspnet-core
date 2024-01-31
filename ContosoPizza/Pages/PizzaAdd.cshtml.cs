using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Pages
{
    public class PizzaAddModel : PageModel
    {
        private readonly PizzaService _service;

        [BindProperty]
        public Pizza NewPizza { get; set; } = default!;

        public PizzaAddModel(PizzaService service){
            _service = service;
        }

         public IActionResult OnPost()
        {
            if (!ModelState.IsValid || NewPizza == null)
            {
                return Page();
            }

            _service.AddPizza(NewPizza);

            return RedirectToPage("PizzaList");
        }
    }
}
