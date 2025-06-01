using Microsoft.AspNetCore.Mvc.RazorPages;
using Ayra.Application.Services;
using Ayra.Domain.Entities;

namespace Ayra.Api.Pages.Alerts
{
    public class IndexModel : PageModel
    {
        private readonly AlertService _alertService;

        public IndexModel(AlertService alertService)
        {
            _alertService = alertService;
        }

        // Propriedade pública que será usada na view
        public IEnumerable<Alert> Alerts { get; set; }

        // Método executado quando a página é carregada (GET)
        public async Task OnGetAsync()
        {
            Alerts = await _alertService.GetAllAsync();
        }
    }
}