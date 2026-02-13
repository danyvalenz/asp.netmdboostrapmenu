using cruddemo.Data;
using cruddemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace cruddemo.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDBContext _applicationDBContext;

        public MenuController(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Alta()
        {
            var padres = _applicationDBContext.MenusLaterales
                .Where(m=> m.ParentId == null)
                .ToList();

            var hijos = _applicationDBContext.MenusLaterales
                .Where(m => m.ParentId == 12)
                .ToList();
            ViewBag.ParentId = new SelectList(padres, "Id", "Texto");
            return View();
        }
        public IActionResult Baja()
        {
            return View();
        }

        public async Task<IActionResult> Create(MenuLateral menuLateral)
        {
            if (ModelState.IsValid)
            {
                var hijos = _applicationDBContext.MenusLaterales
                                .Where(m => m.ParentId == menuLateral.ParentId)
                                .Max(p => p.Orden);


                int orden = hijos + 1;
                menuLateral.Orden = orden;
                _applicationDBContext.MenusLaterales.Add(menuLateral);
                await _applicationDBContext.SaveChangesAsync();

                //https://localhost:7135/Menu/Home/Index

                return RedirectToAction("/");
            }

            ViewBag.ParentId = new SelectList(_applicationDBContext.MenusLaterales.Where(m => m.ParentId == null), "Id", "Texto", menuLateral.ParentId);
            return View(menuLateral);

        }
    }
}
