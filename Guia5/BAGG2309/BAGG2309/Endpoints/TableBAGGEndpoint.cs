using BAGG202309.DTOs;
using BAGG202309.DTOs.TableBAGGDTOs;
using BAGG2309.Models.DAL;
using BAGG2309.Models.EN;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BAGG2309.Endpoints
{
    public static class TableBAGGEndpoint
    {
        public static void AddTableBAGGEndpoints(this WebApplication app)
        {
            app.MapPost("/Juego/search", async (SearchQueryBAGGDTO baggDTO, TableBAGGDAL baggDAL) =>
            {
                var tableBAGG = new TableBAGG
                {
                    NombreJuego = baggDTO.NombreJuego_Like != null ? baggDTO.NombreJuego_Like : string.Empty,
                    Compania = baggDTO.Compania_Like != null ? baggDTO.Compania_Like : string.Empty
                };

                var tableBAGGs = new List<TableBAGG>();
                int countRow = 0;

                if (baggDTO.SendRowCount == 2)
                {
                    tableBAGGs = await baggDAL.Search(tableBAGG, skip: baggDTO.Skip, take: baggDTO.Take);
                }
                else
                {
                    tableBAGGs = await baggDAL.Search(tableBAGG, skip: baggDTO.Skip, take: baggDTO.Take);
                }

                var baggResult = new SearchResultBAGGDTO
                {
                    Data = new List<SearchResultBAGGDTO.BAGGDTO>(),
                    CountRow = countRow
                };

                tableBAGGs.ForEach(x =>
                {
                    baggResult.Data.Add(new SearchResultBAGGDTO.BAGGDTO
                    {
                        Id = x.Id,
                        NombreJuego = x.NombreJuego,
                        Compania = x.Compania,
                        Ventas = x.Ventas,
                        Puntuacion = x.Puntuacion,
                        FechaLanzamiento = x.FechaLanzamiento
                    });
                });
                return baggResult;
            });

            app.MapGet("/Juegos/{id}", async(int id, TableBAGGDAL baggDAL) =>
            {
                var tableBAGG = await baggDAL.GetById(id);

                var baggResult = new GetIdBAGGDTO
                {
                    Id = tableBAGG.Id,
                    NombreJuego = tableBAGG.NombreJuego,
                    Compania = tableBAGG.Compania,
                    Ventas = tableBAGG.Ventas,
                    Puntuacion = tableBAGG.Puntuacion,
                    FechaLanzamiento = tableBAGG.FechaLanzamiento
                };
                if (baggResult.Id > 0)
                    return Results.Ok(baggResult);
                else
                    return Results.NotFound(baggResult);
            });

            app.MapPost("/Juegos", async (CreateBAGGDTO baggDTO, TableBAGGDAL baggDAL) =>
            {
                var tableBAGG = new TableBAGG
                {
                    NombreJuego = baggDTO.NombreJuego,
                    Compania = baggDTO.Compania,
                    Ventas = baggDTO.Ventas,
                    Puntuacion = baggDTO.Puntuacion,
                    FechaLanzamiento = baggDTO.FechaLanzamiento
                };

                int result = await baggDAL.Create(tableBAGG);
                if (result != 0)
                    return Results.Ok(result);
                else
                return Results.StatusCode(500);
            });

            app.MapPut("/Juegos", async (EditBAGGDTO baggDTO, TableBAGGDAL baggDAL) =>
            {
                var tableBAGG = new TableBAGG
                {
                    Id = baggDTO.Id,
                    NombreJuego = baggDTO.NombreJuego,
                    Compania = baggDTO.Compania,
                    Ventas = baggDTO.Ventas,
                    Puntuacion = baggDTO.Puntuacion,
                    FechaLanzamiento = baggDTO.FechaLanzamiento
                };
                int result = await baggDAL.Edit(tableBAGG);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });

            app.MapDelete("/Juegos/{id}", async (int id, [FromBody] DeleteBAGGDTO deleteDTO, TableBAGGDAL baggDAL) =>
            {
                int result = await baggDAL.Delete(id);

                if (result != 0)
                {
                    return Results.NoContent();
                }
                else
                {
                    return Results.StatusCode(500);
                }
            });


        }
    }
}
