using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using app.neptuno.dto;

namespace app.neptuno.data
{
    public class InVentaCabData
    {
        private readonly DataContext context;

        public InVentaCabData(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<InVentaDetDTO>> GetDetalleVenta(int IdClasif1, List<int> Bodegas, DateTime FechaIni, DateTime FechaFin)
        {
            try
            {
                var query = from a in this.context.VentaDet
                            join b in this.context.VentaCab on a.id_venta_cab equals b.id_venta_cab
                            join c in this.context.Item on a.id_producto equals c.id_item
                            join d in this.context.NodoClasif1 on c.id_clasif_1 equals d.id_nodo_clasif_1
                            where b.fecha >= FechaIni
                            && b.fecha <= FechaFin
                            && Bodegas.Contains(b.id_bodega)
                            && c.id_clasif_1 == IdClasif1
                            select new InVentaDetDTO
                            {
                                IdVentaDet = a.id_venta_det,
                                IdVentaCab = a.id_venta_cab,
                                SecuenciaDet = a.secuencia_det,
                                IdBodega = a.id_bodega,
                                IdProducto = a.id_producto,
                                CantidadUnidad = a.cantidad_unid,
                                CantidadFrac = a.cantidad_frac,
                                CostoUnitario0 = a.costo_unitario_0,
                                CostoUnitario1 = a.costo_unitario_1,
                                CostoTotal0 = a.costo_total_0,
                                CostoTotal1 = a.costo_total_1
                            };

                return await query.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}