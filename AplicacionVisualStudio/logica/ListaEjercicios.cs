using AplicacionVisualStudio.Clases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionVisualStudio.logica
{
    public class ListaEjercicios
    {
        public static ObservableCollection<Ejercicio> listaEjercicios { get; set; } = new ObservableCollection<Ejercicio>(); //Usamos distintos tipos de listas de objetos dependiendo de su uso(List, ObservableCollection...)

        /*public ListaEjercicios()
        {
            listaEjercicios = new ObservableCollection<Ejercicio>();
            listaEjercicios.Add(new Ejercicio("nombre","peso","series","repeticiones"));
        }*/
        public void añadirEjercicio(Ejercicio ejercicio)
        {
            listaEjercicios.Add(ejercicio);
        }

        public void modificarEjercicio(Ejercicio ejercicio, int cont)
        {
            listaEjercicios[cont] = ejercicio;
        }

        public static ObservableCollection<Ejercicio> getListaEjercicios()
        {
            return listaEjercicios;
        }




    }
}
