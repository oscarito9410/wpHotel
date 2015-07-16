using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Becarios.View
{
    /// <summary>
    /// Interaction logic for ClientesView.xaml
    /// </summary>
    public partial class ClientesView : MetroWindow
    {

        private ViewModel.ViewModelClient viewModel;
        public ClientesView()
        {
            InitializeComponent();
            this.viewModel = new ViewModel.ViewModelClient();
            this.suscribe();
            this.DataContext = viewModel;
        }
        
        private  void suscribe()
        {
            this.viewModel.OnWindowActionEvent +=(s, args) => {

                args.MWindow.Show();
                this.Close();
            };
            this.viewModel.OnMessageDailogShowEvent += async(s, args) => {
                    await this.ShowMessageAsync(args.Title, args.Content);
            };
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);

        }

        private async void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            if (combo != null)
            {
               viewModel.listHabitacionesDisponibles = await viewModel.crudHelper.getHabitacionesDisponibles(combo.SelectedValue.ToString());
            }
        }
        
       
    }
}
