using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.neptuno.data;
using app.neptuno.dto;
using System.Text.Json;

namespace app.neptuno.business
{
    public class InNodoClasif1Bus
    {
        private InNodoClasif1Data data;

        public InNodoClasif1Bus(DataContext context){
            this.data = new InNodoClasif1Data(context);            
        }

        // metodo devuelve nodos formateados
        public async Task<List<InNodoClasif1DTO>> GetAll(){
            // Obtener los datos de la base de datos y almacenarlos en una lista
            List<InNodoClasif1DTO> nodos = new List<InNodoClasif1DTO>();

            // Lógica para obtener los datos de la base de datos y llenar la lista 'nodos'
            nodos = await this.data.GetAll();
            
            // Convertir la lista de nodos a la estructura jerárquica deseada
            List<InNodoClasif1DTO> nodos_padres = nodos.FindAll(n => n.IdPadre == null);

            foreach(var raiz in nodos_padres){
                AsignarHijos(raiz, nodos);
            }

            // Función recursiva para asignar los nodos secundarios a cada nodo padre
            void AsignarHijos(InNodoClasif1DTO nodoPadre, List<InNodoClasif1DTO> nodos)
            {
                nodoPadre.children = nodos.Where(n => n.IdPadre == nodoPadre.IdNodoClasif1).ToList();

                foreach (InNodoClasif1DTO hijo in nodoPadre.children)
                {
                    AsignarHijos(hijo, nodos);
                }
            }
            
            return nodos_padres;
        }
    }
}