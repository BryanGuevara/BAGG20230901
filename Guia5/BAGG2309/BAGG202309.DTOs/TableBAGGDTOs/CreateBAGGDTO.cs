using System.ComponentModel.DataAnnotations;

namespace BAGG202309.DTOs.TableBAGGDTOs
{
    public class CreateBAGGDTO
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "El Campo Nombre no puede tener mas de 50 caracteres")]
        public string NombreJuego { get; set; }

        [Display(Name = "Compañia")]
        [MaxLength(50, ErrorMessage = "El Campo Compañia no puede tener mas de 50 caracteres")]
        public string Compania { get; set; }

        [Display(Name = "Ventas")]
        [Required(ErrorMessage = "El campo Ventas es obligatorio")]
        public int Ventas { get; set; }

        [Display(Name = "Puntuacion")]
        [MaxLength(2, ErrorMessage = "El Campo Puntuasion no puede tener mas de 2 caracteres")]
        public decimal Puntuacion { get; set; }

        [Display(Name = "Fecha de Lanzamiento")]
        public DateTime FechaLanzamiento { get; set; }

    }
}
