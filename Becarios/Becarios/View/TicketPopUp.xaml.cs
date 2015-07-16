using MahApps.Metro.SimpleChildWindow;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Becarios.View
{
    /// <summary>
    /// Interaction logic for TicketPopUp.xaml
    /// </summary>
    public partial class TicketPopUp : ChildWindow
    {
        private int clv_orden { get; set; }
        public TicketPopUp(int clv_orden)
        {
            InitializeComponent();
            this.clv_orden = clv_orden;
        }
        private void reportViewer_Load(object sender, EventArgs e)
        {
            this.loadReporte(clv_orden);
        }
        private void loadReporte(int clv_orden = 0)
        {

            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSource1.Name = "gastoTicket";
            reportDataSource1.Value = new Bd.ReportHelper().getTicket(clv_orden).total_gasto;
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            reportViewer.LocalReport.ReportEmbeddedResource = "Becarios.Ticket.rdlc";
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.RefreshReport();

        }
    }
}
