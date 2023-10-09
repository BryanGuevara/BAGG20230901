using System.ComponentModel.DataAnnotations;

namespace BAGG202309.DTOs.TableBAGGDTOs
{
    public class EditBAGGDTO
    {
        public EditBAGGDTO(GetIdBAGGDTO getIdBAGGDTO) 
        {
            Id = getIdBAGGDTO.Id;
            NombreJuego = getIdBAGGDTO.NombreJuego;
            Compania = getIdBAGGDTO.Compania;
            Ventas = getIdBAGGDTO.Ventas;
            Puntuacion = getIdBAGGDTO.Puntuacion;
            FechaLanzamiento = getIdBAGGDTO.FechaLanzamiento;
        }

        public EditBAGGDTO()
        {
            NombreJuego = string.Empty;
            Compania = string.Empty;
        }

        [Required(ErrorMessage = "El campo Id es Obligatorio")]
        public int Id { get; set; }

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

        [Display(Name = "Puntuación")]
        [MaxLength(2, ErrorMessage = "El Campo Puntuación no puede tener mas de 2 caracteres")]
        public decimal Puntuacion { get; set; }

        [Display(Name = "Fecha de Lanzamiento")]
        public DateTime FechaLanzamiento { get; set; }

    }
}
