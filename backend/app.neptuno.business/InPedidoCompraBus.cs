using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.neptuno.data;
using app.neptuno.dto;

namespace app.neptuno.business
{
    public class InPedidoCompraBus
    {
        private InItemBodegaData dataItemBodega;
        private InVentaCabData dataInVenta;

        public InPedidoCompraBus(DataContext context)
        {
            this.dataItemBodega = new InItemBodegaData(context);
            this.dataInVenta = new InVentaCabData(context);
        }

        public async Task<List<InPedidoCompraDetDTO>> GenerarDetalle(DateTime FechaIni, DateTime FechaFin, int IdClasif1, List<int> Bodegas)
        {
            try
            {
                // lista pedido de compra detalle
                List<InPedidoCompraDetDTO> PedidoCompraDet = new List<InPedidoCompraDetDTO>();

                // Obtengo la lista de items por bodega
                List<InItemBodegaDTO> itemBodegaList = await this.dataItemBodega.GetItemBodega(Bodegas, IdClasif1);

                // Obtengo la lista de venta de inventario detalle
                List<InVentaDetDTO> ventaDetalles = await this.dataInVenta.GetDetalleVenta(IdClasif1, Bodegas, FechaIni, FechaFin);

                // Agrupar la lista por IdBodega e IdItem y sumar la CantidadUnidad utilizando la sintaxis de método
                var groupedVentaDetalles = ventaDetalles
                    .GroupBy(vd => new { vd.IdBodega, vd.IdProducto })
                    .Select(group => new
                    {
                        IdBodega = group.Key.IdBodega,
                        IdItem = group.Key.IdProducto,
                        SumCantidadUnidad = group.Sum(vd => vd.CantidadUnidad)
                    });

                foreach (var itemBodega in itemBodegaList)
                {
                    int _ventaMes = 0;

                    if (groupedVentaDetalles != null)
                    {
                        // obtengo detalle por IdBodega, IdItem
                        var _itemVentaDet = groupedVentaDetalles.FirstOrDefault(q => q.IdBodega == itemBodega.IdBodega
                        && q.IdItem == itemBodega.IdItem);

                        _ventaMes = _itemVentaDet == null ? 0 : _itemVentaDet.SumCantidadUnidad;
                    }

                    InPedidoCompraDetDTO _pedidoCompraDet = new InPedidoCompraDetDTO();
                    _pedidoCompraDet.IdPedidoDetalle = 0;
                    _pedidoCompraDet.IdPedido = 0;
                    _pedidoCompraDet.IdBodega = itemBodega.IdBodega;
                    _pedidoCompraDet.IdItem = itemBodega.IdItem;
                    // _pedidoCompraDet.BodegaCodigo = itemBodega.Bodega.Codigo;
                    // _pedidoCompraDet.BodegaNombre = itemBodega.Bodega.Nombre;
                    _pedidoCompraDet.StockActual = (itemBodega.StockUnidad + itemBodega.StockFraccion);
                    _pedidoCompraDet.VentaMes = _ventaMes;
                    _pedidoCompraDet.CantidadIngresada = 0;
                    // _pedidoCompraDet.ItemDescripcion = itemBodega.Item.Descripcion;
                    // _pedidoCompraDet.ItemCodigoBarra = itemBodega.Item.CodBarra;

                    PedidoCompraDet.Add(_pedidoCompraDet);
                }

                return PedidoCompraDet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}