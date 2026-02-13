using cruddemo.Data;
using cruddemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cruddemo.Controllers
{
    public class ContactosController : Controller
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public ContactosController(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        public async Task<IActionResult> Index()
        {
            var contactos = await _applicationDBContext.Contactos.ToListAsync();
            return View(contactos);
        }

        [HttpGet]
        public async Task<IActionResult> NuevoContacto()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GuardarContacto(Contacto contacto)
        {
            return View();
        }
    }
}
