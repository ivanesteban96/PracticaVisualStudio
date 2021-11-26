using AplicacionVisualStudio.Clases;
using AplicacionVisualStudio.logica;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AplicacionVisualStudio
{
    public partial class MainWindow : Window                           //Realizamos algún Binding entre 2 componentes gráficos 
    {
        private ListaEjercicios listaEjercicios;                       //Usamos DataGrid para mostrar información. Sin personalizar la salida
        public List<Atleta> listaAtletas { get; set; }                 //Ídem pero configurándolo con DataGrid.Columns 

        public ObservableCollection<Atleta> listaAtletas2 { get; set; } = new ObservableCollection<Atleta>();

        public MainWindow()
        {
            InitializeComponent();

            listaEjercicios = new ListaEjercicios();

            DataGridEjercicios.DataContext = listaEjercicios;

            listaAtletas = ListaAtletas.getListaAtletas();        

            listaAtletas.Add(new Atleta("paco", "80kg", "24"));
            listaAtletas.Add(new Atleta("luis", "70kg", "22"));

            //ComboBoxAtletas.DataContext = this;

            foreach (Atleta atleta in listaAtletas)  
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = atleta;
                ComboBoxAtletas.Items.Add(cbi);
            }

            //DataGridAtletas.DataContext = this;

            Atleta atleta1 = listaAtletas[0];
            Atleta atleta2 = listaAtletas[1];
            lblAtleta1.DataContext = atleta1;
            lblAtleta2.DataContext = atleta2;




        }
        private void BotonRegistrar_Click(object sender, RoutedEventArgs e)
        {
            DialogoEjercicio dialogoEjercicio = new DialogoEjercicio(listaEjercicios);

            dialogoEjercicio.Show();

        }

        private void BotonModificar_Click(object sender, RoutedEventArgs e)   //Somos capaces de conseguir que el DataGrid (o el componente que sea) se actualice, no solo con la inclusión/eliminación de nuevos elementos, sino también al cambiar alguna propiedad de alguno de ellos. (INotifyPropertyChanged) x4
        {
            if (DataGridEjercicios.SelectedIndex!=-1)
            {
                Ejercicio ejercicio =(Ejercicio) DataGridEjercicios.SelectedItem;

                DialogoEjercicio dialogoEjercicio = new DialogoEjercicio(listaEjercicios,(Ejercicio)ejercicio.Clone(),DataGridEjercicios.SelectedIndex);   //Utilizamos el interfaz ICloneable para manejar información temporal (no tocamos el objeto que hemos clonado) x3

                dialogoEjercicio.Show();
            }
        }

        private void CambiarAtleta(object sender, SelectionChangedEventArgs e)  //Usamos eventos diferentes del básico del componente x2 
        {
            ComboBoxItem cbi = (ComboBoxItem)ComboBoxAtletas.SelectedItem;  
            Atleta atleta= (Atleta)cbi.Content;
            this.DataContext = atleta;

            /*if(atleta.nombre.Equals("paco"))
            {
                atleta = listaAtletas[0];
            }
            else
            {
                atleta = listaAtletas[1];
            }*/

            listaAtletas2.Clear();
            listaAtletas2.Add(atleta);

            DataGridAtletas.DataContext = this;
        }

      
    }
}
