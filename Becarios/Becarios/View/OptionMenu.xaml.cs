using MahApps.Metro.Controls;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls.Dialogs;
namespace Becarios.View
{
    /// <summary>
    /// Interaction logic for OptionMenu.xaml
    /// </summary>
    public partial class OptionMenu : MetroWindow
    {
        public OptionMenu()
        {
            InitializeComponent();
        }

        private void tileCliente_Click(object sender, RoutedEventArgs e)
        {
            new ClientesView().Show();
            this.Close();

        }

        private void tileHabitaciones_Click(object sender, RoutedEventArgs e)
        {
           
            new Habitaciones().Show();
            this.Close();

        }

        private void tileReservaciones_Click(object sender, RoutedEventArgs e)
        {
            new ProductosView().Show();
            this.Close();
        }

        private void tileRestaurante_Click(object sender, RoutedEventArgs e)
        {
            new Restaurante().Show();
            this.Close();

        }

        private async void tileExit_Click(object sender, RoutedEventArgs e)
        {
           var result=await this.ShowMessageAsync("Salir", "¿Estás seguro de salir?", MessageDialogStyle.AffirmativeAndNegative);
            if (result == MessageDialogResult.Affirmative)
            {
                new MainWindow().Show();
                this.Close();
            }
        }

        private void tileConsultas_Click(object sender, RoutedEventArgs e)
        {
            new ReporteGastos().Show();
            this.Close();

        }
    }
}
