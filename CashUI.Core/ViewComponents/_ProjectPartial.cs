using Microsoft.AspNetCore.Mvc;

namespace CashUI.Core.ViewComponents
{
    public class _ProjectPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}