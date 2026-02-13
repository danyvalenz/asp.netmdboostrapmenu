using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cruddemo.Models
{
    public class MenuLateral
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Texto { get; set; }

        // Ahora pueden ser nulos si el ítem es solo un contenedor (como "Ventas")
        public string? Controller { get; set; }
        public string? Action { get; set; }

        public string Icono { get; set; }

        public int Orden { get; set; }

        // --- NUEVAS PROPIEDADES ---

        // Si ParentId es null, es un ítem de nivel superior o un Módulo.
        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual MenuLateral? Parent { get; set; }

        public virtual ICollection<MenuLateral> SubMenus { get; set; } = new List<MenuLateral>();
    }
}
