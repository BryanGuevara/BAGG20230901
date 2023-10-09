using System.ComponentModel.DataAnnotations;

namespace BAGG202309.DTOs.TableBAGGDTOs
{
    public class SearchResultBAGGDTO
    {
        public int CountRow {  get; set; }
        public List<BAGGDTO> Data { get; set; }

        public class BAGGDTO
        {
            public int Id { get; set; }

            [Display(Name = "Nombre")]
            public string NombreJuego { get; set; }

            [Display(Name = "Compañia")]
            public string Compania { get; set; }

            [Display(Name = "Ventas")]
            public int Ventas { get; set; }

            [Display(Name = "Puntuación")]
            public decimal Puntuacion { get; set; }

            [Display(Name = "Fecha de Lanzamiento")]
            public DateTime FechaLanzamiento { get; set; }

        }
    }
}
