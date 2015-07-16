using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.SimpleChildWindow;
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
    /// Interaction logic for ProductosView.xaml
    /// </summary>
    public partial class ProductosView : MetroWindow
    {
        ViewModel.ViewModelProductos viewModel = new ViewModel.ViewModelProductos();
        public ProductosView()
        {
            InitializeComponent();
            this.DataContext = viewModel;
            this.suscribe();
           
          
        }
      
        private void suscribe()
        {
            this.viewModel.OnWindowActionEvent += (s, args) => {

                args.MWindow.Show();
                this.Close();
            };
            this.viewModel.OnMessageDailogShowEvent += async (s, args) => {
                await this.ShowMessageAsync(args.Title, args.Content);
            };
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);

        }
    }
}
