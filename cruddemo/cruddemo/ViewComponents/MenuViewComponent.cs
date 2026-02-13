using cruddemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cruddemo.ViewComponents
{
    public class MenuViewComponent :ViewComponent
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public MenuViewComponent(ApplicationDBContext applicationDBContext)
        {
            this._applicationDBContext = applicationDBContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var todosLosMenus = await _applicationDBContext.MenusLaterales.ToListAsync();

            // 2. Filtramos solo los que son Raíz (ParentId == null)
            // Al estar ya todos en memoria, EF vincula las colecciones SubMenus automáticamente
            var menuRaiz = todosLosMenus
                .Where(m => m.ParentId == null)
                .OrderBy(m => m.Orden)
                .ToList();
            return View(menuRaiz);
        }
    }
}
