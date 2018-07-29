using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLuisMendozaSamuel.ViewComponents
{
    public class IdiomaViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult>
       InvokeAsync()
        {
            var idiomas = new List<SelectListItem>();
            idiomas.Add(new SelectListItem() { Value = "en-US", Text = "English" });
            idiomas.Add(new SelectListItem() { Value = "es-PE", Text = "Español" });

            var currentCulture = HttpContext.Features.Get<IRequestCultureFeature>();
            ViewBag.IdiomaSeleccionado = currentCulture.RequestCulture.UICulture.Name;
            return View(idiomas);
        }
    }
}
