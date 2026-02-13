using System.ComponentModel.DataAnnotations;

namespace cruddemo.Models
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido")]
        public string Correo { get; set; }

        [Phone(ErrorMessage = "Ingrese un formato de teléfono válido")]
        [StringLength(20)] // Más flexible para formatos internacionales
        public string Telefono { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
