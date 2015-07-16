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
using FirstFloor.ModernUI.Windows.Controls;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MySql.Data.MySqlClient;
using Microsoft.Win32;
using System.Data;
namespace Becarios
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
     
         
        private ViewModel.ViewModelUsuario viewModel = new ViewModel.ViewModelUsuario();
        public MainWindow()
        {
           
            InitializeComponent();
            this.DataContext =viewModel;
            this.suscribeEvent();
        }

        private  void suscribeEvent()
        {
            viewModel.OnMessageDailogShowEvent += (s, args) =>
            {
                this.ShowMessageAsync(args.Title, args.Content);
            };
            viewModel.OnWindowActionEvent+= (s, args) =>
            {
                if (args.IsClose == true) {
                    args.MWindow.Show();
                    this.Close();
                }
            };
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            /*
            using (MySqlConnection MidbConexion = new MySqlConnection(Miruta))
            {
                MidbConexion.Open();//Abrimos la conexion para realizar los siguientes pasos
                // 'Declaro comando para poder realizar mis instrucciones sql
                MySqlCommand micomando = new MySqlCommand { Connection = MidbConexion, CommandText = "INSERT INTO Aspirantes(nombre,edad,imageUri) VALUES (?Nom,?Pass,?imageUri)" };
                micomando.Parameters.AddWithValue("?Nom", txtNombre.Text);
                micomando.Parameters.AddWithValue("?Pass", txtNumeric.Value.ToString());
                micomando.Parameters.AddWithValue("?imageUri", this.rutaImagen);
                micomando.ExecuteNonQuery();
                await this.ShowMessageAsync("Becario ingresado", "Ingresado correctamente");
            }
            */
       
 
       
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {

            /*
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                this.imageUri.Source = new BitmapImage(new Uri(op.FileName));
            }
            this.rutaImagen = op.FileName;
            */

        }
        //http://ltuttini.blogspot.mx/2009/11/c-adonet-ejemplo-practico-recuperar.html
        private void Load(object sender, RoutedEventArgs e)
        {
            /*
            String sql = "SELECT*FROM aspirantes where id=15";
            using(MySqlConnection conn = new MySqlConnection(this.Miruta))
            {
                MySqlCommand command = new MySqlCommand(sql,conn);
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    this.txtNombre.Text = reader["nombre"].ToString();
                    this.txtNumeric.Value =Convert.ToDouble(reader["edad"]);
                    this.imageUri.Source = new BitmapImage(new Uri(reader["imageUri"].ToString()));
                }
            }
            */
           
        }

        private void passwordLogin_PasswordChanged(object sender, RoutedEventArgs e)
        {
            this.viewModel.password = passwordLogin.Password;
        }

        private void passwordRegistrar_PasswordChanged(object sender, RoutedEventArgs e)
        {
            this.viewModel.passwordRegistrar = passwordRegistrar.Password;
        }

        private void passwordConfirmar_PasswordChanged(object sender, RoutedEventArgs e)
        {
            this.viewModel.passwordConfirmar = passwordConfirmar.Password;
        }
    }
}
