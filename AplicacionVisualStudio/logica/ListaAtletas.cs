using AplicacionVisualStudio.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionVisualStudio.logica
{
    public class ListaAtletas
    {
        public static List<Atleta> listaAtletas { get; set; } = new List<Atleta>();  //Usamos distintos tipos de listas de objetos dependiendo de su uso (List, ObservableCollection...)
        public static List<Atleta> getListaAtletas()
        {
            return listaAtletas;
        }
        

    }
}
