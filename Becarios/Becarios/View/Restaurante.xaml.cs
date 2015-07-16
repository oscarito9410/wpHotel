using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.SimpleChildWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Becarios.View
{
    /// <summary>
    /// Interaction logic for Restaurante.xaml
    /// </summary>
    public partial class Restaurante : MetroWindow
    {
        private ViewModel.ViewModelRestaurante viewModel;
        public Restaurante()
        {
            InitializeComponent();
            this.viewModel = new ViewModel.ViewModelRestaurante();
            this.DataContext = viewModel;
            this.suscribe();
           
        }
     
        private void suscribe()
        {
            this.viewModel.OnChildShowEvent += async (s, args) =>
            {
                await this.ShowChildWindowAsync(new View.TicketPopUp(Convert.ToInt32(args.Args)) { IsModal = true, AllowMove = true }, rootGrid);

            };
            this.viewModel.OnWindowActionEvent += (s, args) => {
                args.MWindow.Show();
                this.Close();
            };
            this.viewModel.OnMessageDailogShowEvent += async (s, args) => {
                await this.ShowMessageAsync(args.Title, args.Content);
            };
            this.numericUpdown.ValueChanged += (s, args) => {

                this.viewModel.updatePrecio();
                        
            };
        }


        private void uno_Click(object sender, RoutedEventArgs e)
        {
            var toogle = sender as ToggleButton;
            this.unCheckedAll(toogle.Name);
        }

        private void unCheckedAll(String name)
        {
            int count = 1;
            IEnumerable<ToggleButton> buttons = groupMesas.FindChildren<ToggleButton>().OfType<ToggleButton>();
            foreach(var button in buttons)
            {
                if(!button.Name.Equals(name)&& button.IsChecked==true)
                {
                    button.IsChecked = false;
                }
                if(button.Name.Equals(name))
                {
                    this.viewModel.selectedMesa = count;
                }
                count++;
         
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listView = sender as ListView;
            if (listView != null) {
                var producto=listView.SelectedItem as Model.Producto;
                ViewModel.ProductoOrden ordenProducto = new ViewModel.ProductoOrden();
                                                                                                                                                ordenProducto.cantidad = producto.cantidad;
                ordenProducto.descripcion = producto.descripcion;
                ordenProducto.clvProducto = producto.clvProducto;
                ordenProducto.precio = producto.precio;
                ordenProducto.categoria = producto.categoria;
                viewModel.selectedProducto = ordenProducto;
     
            }     

        }
    }
}
