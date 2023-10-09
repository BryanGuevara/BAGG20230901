using System.ComponentModel.DataAnnotations;

namespace BAGG202309.DTOs.TableBAGGDTOs
{
    public class SearchQueryBAGGDTO
    {
        [Display(Name = "Nombre del Juego")]
        public string? NombreJuego_Like { get; set; }

        [Display(Name = "Compañía")]
        public string? Compania_Like { get; set; }

        [Display(Name = "Página")]
        public int Skip { get; set; }

        [Display(Name = "Cantidad de Registros por Página")]
        public int Take { get; set; }

        [Display(Name = "Enviar Conteo de Filas")]
        public byte SendRowCount { get; set; }
    }
}
