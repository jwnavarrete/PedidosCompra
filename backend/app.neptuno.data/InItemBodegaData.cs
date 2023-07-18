using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using app.neptuno.dto;

namespace app.neptuno.data
{
    public class InItemBodegaData
    {
        private readonly DataContext context;

        public InItemBodegaData(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<InItemBodegaDTO>> GetItemBodega(List<int> ListBodega, int IdClasif1)
        {
            try
            {
                // inner join in_nodo_clasif_1 B on A.id_clasif_1 = B.id_nodo_clasif_1 
                var query = from a in this.context.ItemBodega
                            join b in this.context.Item on a.id_item equals b.id_item
                            join c in this.context.Bodega on a.id_bodega equals c.id_bodega                            
                            join d in this.context.NodoClasif1 on b.id_clasif_1 equals d.id_nodo_clasif_1
                            where a.id_estado_item == 1
                            && a.habilitado == "S"
                            && ListBodega.Contains(a.id_bodega)
                            && b.id_clasif_1 == IdClasif1
                            select new InItemBodegaDTO
                            {
                                IdItemBodega = a.id_item_bodega,
                                IdBodega = a.id_bodega,
                                IdItem = a.id_item,
                                IdEstadoItem = a.id_estado_item,
                                Habilitado = a.habilitado,
                                StockUnidad = a.stock_unidad,
                                StockFraccion = a.stock_fraccion,
                                StockActual = (a.stock_unidad + a.stock_fraccion),
                                // Item = new InItemDTO
                                // {
                                //     IdItem = b.id_item,
                                //     Descripcion = b.descripcion,
                                //     CodBarra = b.cod_barra,
                                //     Precio = b.precio,
                                //     TipoItem = b.tipo_item,
                                //     AplicaIva = b.aplica_iva
                                // },
                                // Bodega = new InBodegaDTO
                                // {
                                //     IdBodega = c.id_bodega,
                                //     Codigo = c.codigo,
                                //     Nombre = c.nombre,
                                //     Activo = c.activo,
                                //     NombreCompleto = "[" + c.codigo + "] - " + c.nombre
                                // }
                            };

                return await query.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<InItemBodegaDTO>> GetAll(int IdClasif1, List<int> ListBodega)
        {
            try
            {
                // inner join in_nodo_clasif_1 B on A.id_clasif_1 = B.id_nodo_clasif_1 
                var query = from a in this.context.ItemBodega
                            join b in this.context.Item on a.id_item equals b.id_item
                            join c in this.context.Bodega on a.id_bodega equals c.id_bodega                            
                            join d in this.context.NodoClasif1 on b.id_clasif_1 equals d.id_nodo_clasif_1
                            where a.id_estado_item == 1
                            && a.habilitado == "S"
                            && ListBodega.Contains(a.id_bodega)
                            && b.id_clasif_1 == IdClasif1
                            select new InItemBodegaDTO
                            {
                                IdItemBodega = a.id_item_bodega,
                                IdBodega = a.id_bodega,
                                IdItem = a.id_item,
                                IdEstadoItem = a.id_estado_item,
                                Habilitado = a.habilitado,
                                StockUnidad = a.stock_unidad,
                                StockFraccion = a.stock_fraccion,
                                StockActual = (a.stock_unidad + a.stock_fraccion),
                                Item = new InItemDTO
                                {
                                    IdItem = b.id_item,
                                    Descripcion = b.descripcion,
                                    CodBarra = b.cod_barra,
                                    Precio = b.precio,
                                    TipoItem = b.tipo_item,
                                    AplicaIva = b.aplica_iva
                                },
                                Bodega = new InBodegaDTO
                                {
                                    IdBodega = c.id_bodega,
                                    Codigo = c.codigo,
                                    Nombre = c.nombre,
                                    Activo = c.activo,
                                    NombreCompleto = "[" + c.codigo + "] - " + c.nombre
                                }
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