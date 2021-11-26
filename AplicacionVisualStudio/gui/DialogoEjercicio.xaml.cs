using AplicacionVisualStudio.Clases;
using AplicacionVisualStudio.logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AplicacionVisualStudio
{                                                                          //Usamos una 2ª ventana
    public partial class DialogoEjercicio : Window                         //Realizamos Binding entre un componente y un objeto 
    {
        private ListaEjercicios listaEjercicios = new ListaEjercicios();
        private Ejercicio ejercicio;
        private int cont;
        Boolean modificar;
        private int errores;

        public DialogoEjercicio(ListaEjercicios listaEjercicios)                           //Realizamos la sobrecarga de algún método, primer constructor para añadir ejercicio
        {
            InitializeComponent();

            ejercicio = new Ejercicio();

            this.DataContext = ejercicio;                                                  //Indicamos que archivo es el origen de datos de nuestra ventana                                          

            modificar = false;
        }

        public DialogoEjercicio(ListaEjercicios listaEjercicios, Ejercicio ejercicioModificado, int cont)  //segundo constructor para modificar ejercicio
        {
            InitializeComponent();
            //this.listaEjercicios = listaEjercicios;

            this.ejercicio = ejercicioModificado;
            this.cont = cont;

            this.DataContext = ejercicio;

            modificar = true;
        }

        private void BotonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BotonRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (modificar == false)
                listaEjercicios.añadirEjercicio(ejercicio);
            else
                listaEjercicios.modificarEjercicio(ejercicio, cont);


            this.Close();
        }

        private void Validation_Error(object sender,ValidationErrorEventArgs e)   //Usamos IDataErrorInfo para validar campos incluyendo NotifyOnValidationError y ValidatesOnDataErrors
        {                                            
            if (e.Action == ValidationErrorEventAction.Added)                     //Asociamos una función a la validación de algún campo
                errores++;
            else
                errores--;

            if (errores == 0)
                BotonRegistrar.IsEnabled = true;
            else
            {
                BotonRegistrar.IsEnabled = false;

            }

        }
    }


}
