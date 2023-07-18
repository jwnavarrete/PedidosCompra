using app.neptuno.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.neptuno.dto;

namespace app.neptuno.data
{
    public class InItemData
    {
        private readonly DataContext context;

        public InItemData(DataContext context)
        {
            this.context = context;
        }

        // consultar
        public async Task<List<InItemDTO>> GetAll()
        {
            var query = from q in this.context.Item
                        select new InItemDTO
                        {
                            IdItem = q.id_item,
                            Descripcion = q.descripcion,
                            CodBarra = q.cod_barra,
                            Precio = q.precio,
                            TipoItem = q.tipo_item,
                            AplicaIva = q.aplica_iva
                        };

            return await query.ToListAsync();
        }

        // consultar por marca
        public async Task<List<InItemDTO>> GetAllByMarca(int IdMarcaItem)
        {
            var query = from q in this.context.Item
                        where q.id_marca_item == IdMarcaItem
                        select new InItemDTO
                        {
                            IdItem = q.id_item,
                            Descripcion = q.descripcion,
                            CodBarra = q.cod_barra,
                            Precio = q.precio,
                            TipoItem = q.tipo_item,
                            AplicaIva = q.aplica_iva
                        };

            return await query.ToListAsync();
        }

        // consultar por IdClasif1
        public async Task<List<InItemDTO>> GetAllByIdClasif1(int IdClasif1)
        {
            var query = from q in this.context.Item
                        where q.id_clasif_1 == IdClasif1
                        select new InItemDTO
                        {
                            IdItem = q.id_item,
                            Descripcion = q.descripcion,
                            CodBarra = q.cod_barra,
                            Precio = q.precio,
                            TipoItem = q.tipo_item,
                            AplicaIva = q.aplica_iva
                        };

            return await query.ToListAsync();
        }

        // consultar por IdClasif1
        public async Task<List<InItemDTO>> GetAll(int IdClasif1, List<int> Bodegas)
        {
            var query = from q in this.context.Item
                        join t in this.context.ItemBodega on q.id_item equals t.id_item into ItemBodegaGroup
                        where q.id_clasif_1 == IdClasif1
                        select new InItemDTO
                        {
                            IdItem = q.id_item,
                            Descripcion = q.descripcion,
                            CodBarra = q.cod_barra,
                            Precio = q.precio,
                            TipoItem = q.tipo_item,
                            AplicaIva = q.aplica_iva,
                            ItemXBodega = ItemBodegaGroup
                            .Where(itemBodega => Bodegas.Contains(itemBodega.id_bodega))
                            .Select(itemBodega => new InItemBodegaDTO
                            {
                                IdItemBodega = itemBodega.id_item_bodega,
                                IdBodega = itemBodega.id_bodega,
                                IdItem = itemBodega.id_item,
                                IdEstadoItem = itemBodega.id_estado_item,
                                Habilitado = itemBodega.habilitado,
                                StockUnidad = itemBodega.stock_unidad,
                                StockFraccion = itemBodega.stock_fraccion,
                                StockActual = (itemBodega.stock_unidad + itemBodega.stock_fraccion)
                            }).ToList()
                        };

            return await query.ToListAsync();
        }

        // consultar por IdClasif1
        public async Task<List<InItemDTO>> GetAllGroupItem(int IdClasif1, List<int> Bodegas)
        {
            var query = from q in this.context.Item
                        join t in this.context.ItemBodega on q.id_item equals t.id_item
                        where q.id_clasif_1 == IdClasif1
                        && Bodegas.Contains(t.id_bodega)
                        group q by new { q.id_item, q.descripcion, q.cod_barra, q.precio, q.tipo_item, q.aplica_iva } into groupResult
                        select new InItemDTO
                        {
                            IdItem = groupResult.Key.id_item,
                            Descripcion = groupResult.Key.descripcion,
                            CodBarra = groupResult.Key.cod_barra,
                            Precio = groupResult.Key.precio,
                            TipoItem = groupResult.Key.tipo_item,
                            AplicaIva = groupResult.Key.aplica_iva
                        };

            return await query.ToListAsync();
        }
    }
}
