using MahApps.Metro.Controls;
using Microsoft.Reporting.WinForms;
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

namespace Becarios.View
{
    /// <summary>
    /// Interaction logic for ReporteGastos.xaml
    /// </summary>
    public partial class ReporteGastos : MetroWindow
    {
        public ReporteGastos()
        {
            InitializeComponent();

        }

        private void reportViewer_Load(object sender, EventArgs e)
        {
            this.loadReporte(0);  
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var clientes =await new Bd.CrudCliente().getAll();
            this.myCombo.ItemsSource = clientes;
        }

        private void myCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCliente = myCombo.SelectedValue as Model.Cliente;
            this.loadReporte(selectedCliente.id);
        }

        private void loadReporteHabitacion()
        {
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSource.Name = "habitacion";
            reportDataSource.Value = new Bd.ReportHelper().getHabitaciones().habitacion_cliente;
            reportViewerHabitaciones.LocalReport.DataSources.Clear();
            reportViewerHabitaciones.LocalReport.DataSources.Add(reportDataSource);
            reportViewerHabitaciones.LocalReport.ReportEmbeddedResource = "Becarios.Habitaciones_Disponibles.rdlc";
            reportViewerHabitaciones.ProcessingMode = ProcessingMode.Local;
            reportViewerHabitaciones.RefreshReport();

        }

        private void loadReporte(int id = 0)
        {
           
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSource1.Name = "gasto";
            reportDataSource1.Value = new Bd.ReportHelper().getGastos(id).total_gasto;
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            reportViewer.LocalReport.ReportEmbeddedResource = "Becarios.GastosCliente.rdlc";
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.RefreshReport();
      
        }

        private void toggleFiltrar_IsCheckedChanged(object sender, EventArgs e)
        {
            if (toggleFiltrar.IsChecked==true)
            {
                this.panelFiltrar.IsEnabled = true;
            }
            else
            {
                this.panelFiltrar.IsEnabled = false;
                this.loadReporte(0);
            }

        }

        private void reportViewerHabitaciones_Load(object sender, EventArgs e)
        {
            this.loadReporteHabitacion();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            new OptionMenu().Show();
            this.Close();
        }
    }
}
