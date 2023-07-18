using app.neptuno.data;
using app.neptuno.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.neptuno.dto;

namespace app.neptuno.business
{
    public class InItemBus
    {
        private InItemData _IntemData;
        private InItemBodegaData _InItemBodegaData;
        private InVentaCabData _InVentaData;

        public InItemBus(DataContext context)
        {
            this._IntemData = new InItemData(context);
            this._InItemBodegaData = new InItemBodegaData(context);
            this._InVentaData = new InVentaCabData(context);
        }

        // consultar
        public async Task<List<InItemDTO>> GetAll()
        {
            return await this._IntemData.GetAll();
        }

        // consultar por marca
        public async Task<List<InItemDTO>> GetAllByMarca(int IdMarcaItem)
        {
            return await this._IntemData.GetAllByMarca(IdMarcaItem);
        }

        public async Task<List<InItemDTO>> GetAllByIdClasif1(int IdClasif1)
        {
            return await this._IntemData.GetAllByIdClasif1(IdClasif1);
        }

        public async Task<List<InItemDTO>> GenerarDetalle(int IdClasif1, List<int> Bodegas, DateTime FechaIni, DateTime FechaFin)
        {
            try
            {
                // Obtengo la lista de items por el campo IdClasif1
                // List<InItemDTO> _Items = await this._IntemData.GetAllByIdClasif1(IdClasif1);
                List<InItemDTO> _Items = await this._IntemData.GetAllGroupItem(IdClasif1, Bodegas);

                // Obtengo la lista de items por bodega
                List<InItemBodegaDTO> itemBodegaList = await this._InItemBodegaData.GetAll(IdClasif1, Bodegas);

                // Obtengo la lista de venta de inventario detalle
                List<InVentaDetDTO> ventaDetalles = await this._InVentaData.GetDetalleVenta(IdClasif1, Bodegas, FechaIni, FechaFin);

                // Recorre lista de items
                foreach (var item in _Items)
                {
                    item.ItemXBodega = itemBodegaList.Where(q => q.IdItem == item.IdItem).ToList();

                    // recorre itemxbodega
                    foreach (var itemBodega in item.ItemXBodega)
                    {
                        if (ventaDetalles != null)
                        {
                            // Agrupar la lista por IdBodega e IdItem y sumar la CantidadUnidad utilizando la sintaxis de método
                            var _itemVentaDet = ventaDetalles
                                .Where(vd => vd.IdProducto == itemBodega.IdItem && vd.IdBodega == itemBodega.IdBodega)
                                .GroupBy(vd => new { vd.IdProducto, vd.IdBodega })
                                .Select(group => new
                                {
                                    SumCantidadUnidad = group.Sum(vd => vd.CantidadUnidad)
                                }).FirstOrDefault();


                            itemBodega.VentaMes = _itemVentaDet == null ? 0 : _itemVentaDet.SumCantidadUnidad;
                        }
                    }
                }

                // Retorna la lista de items que tienen registro de bodega
                return _Items.Where(item => item.ItemXBodega.Count() > 0).ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
