using app.neptuno.data;
using app.neptuno.dto;
using app.neptuno.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.neptuno.business
{
    public class InGrupoBodegaBus
    {
        private InGrupoBodegaData _inGrupoBodegaData;
        private InBodegaBus _inBodega;

        public InGrupoBodegaBus(DataContext context)
        {
            this._inGrupoBodegaData = new InGrupoBodegaData(context);
            this._inBodega = new InBodegaBus(context);
        }

        // consultar
        public async Task<List<InGrupoBodegaDTO>> GetAll()
        {
            return await _inGrupoBodegaData.GetAll();
        }

        public async Task<List<InGrupoBodegaDTO>> GetAllNodes()
        {
            // Obtener los datos de la base de datos y almacenarlos en una lista
            List<InGrupoBodegaDTO> nodos = new List<InGrupoBodegaDTO>();
            List<InBodegaDTO> bodegas = new List<InBodegaDTO>(); 

            // Lógica para obtener los datos de la base de datos y llenar la lista 'nodos'
            nodos = await this._inGrupoBodegaData.GetAll();
            bodegas = await this._inBodega.GetBodegas();

            // Convertir la lista de nodos a la estructura jerárquica deseada
            List<InGrupoBodegaDTO> nodos_padres = nodos.FindAll(n => n.IdPadre == null);

            foreach (var raiz in nodos_padres)
            {
                AsignarHijos(raiz, nodos);
            }

            // Función recursiva para asignar los nodos secundarios a cada nodo padre
            void AsignarHijos(InGrupoBodegaDTO nodoPadre, List<InGrupoBodegaDTO> nodos)
            {
                nodoPadre.Children = nodos.Where(n => n.IdPadre == nodoPadre.IdGrupoBodega).ToList();
                nodoPadre.Bodegas = bodegas.Where(q => q.IdGrupoBodega == nodoPadre.IdGrupoBodega).ToList();

                foreach (InGrupoBodegaDTO hijo in nodoPadre.Children)
                {
                    AsignarHijos(hijo, nodos);
                }
            }

            return nodos_padres;
        }

        public async Task<InGrupoBodegaDTO> GetById(int IdGrupoBodega)
        {
            return await _inGrupoBodegaData.GetById(IdGrupoBodega);
        }
    }
}
