using BAGG2309.Models.EN;
using Microsoft.EntityFrameworkCore;

namespace BAGG2309.Models.DAL
{
    public class TableBAGGDAL
    {
        readonly CRMContext _context;

        public TableBAGGDAL(CRMContext cRMContext)
        {
            _context = cRMContext;
        }

        public async Task<int> Create(TableBAGG tableBAGG)
        {
            _context.Add(tableBAGG);
            return await _context.SaveChangesAsync();
        }

        public async Task<TableBAGG> GetById(int id)
        {
            var tableBAGG = await _context.TableBAGG.FirstOrDefaultAsync(x => x.Id == id);
            return tableBAGG != null ? tableBAGG : new TableBAGG();
        }

        public async Task<int> Edit(TableBAGG tableBAGG)
        {
            int result = 0;
            var tableBAGGUpdate = await GetById(tableBAGG.Id);
            if (tableBAGGUpdate.Id != 0) 
            {
                tableBAGGUpdate.NombreJuego = tableBAGG.NombreJuego;
                tableBAGGUpdate.Compania = tableBAGG.Compania;
                tableBAGGUpdate.Ventas = tableBAGG.Ventas;
                tableBAGGUpdate.Puntuacion = tableBAGG.Puntuacion;
                tableBAGGUpdate.FechaLanzamiento = tableBAGG.FechaLanzamiento;
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        public async Task<int> Delete(int id)
        {
            int result = 0;
            var tableBAGGDelete = await GetById(id);
            if(tableBAGGDelete.Id > 0)
            {
                _context.TableBAGG.Remove(tableBAGGDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        private IQueryable<TableBAGG> Query(TableBAGG tableBAGG)
        {
            var query = _context.TableBAGG.AsQueryable();
            if (!string.IsNullOrWhiteSpace(tableBAGG.NombreJuego))
                query = query.Where(x => x.NombreJuego.Contains(tableBAGG.NombreJuego));
            if (!string.IsNullOrWhiteSpace(tableBAGG.Compania))
                query = query.Where(x => x.Compania.Contains(tableBAGG.Compania));
            return query;
        }

        public async Task<int> CountSearch(TableBAGG tableBAGG)
        {
            return await Query(tableBAGG).CountAsync();
        }

        public async Task<List<TableBAGG>> Search(TableBAGG tableBAGG, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(tableBAGG);
            query = query.OrderByDescending(s => s.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }
}
