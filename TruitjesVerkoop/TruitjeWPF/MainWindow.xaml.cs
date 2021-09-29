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
using BusinessLayer.Model;

namespace TruitjeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Bestelling> bestellingen = new();
        public Bestelling bestelling = new(1002, DateTime.Now, false, Convert.ToDecimal(105.36));       

        public MainWindow()
        {
            InitializeComponent();
            bestellingen.Add(bestelling);
            txtBestellingsnummer.Text = bestelling.Bestellingsnummer.ToString();
            txtDatum.Text = bestelling.Datum.ToString();
            txtVerkoopprijs.Text = bestelling.VerkoopPrijs.ToString();
            txtIsBetaald.Text = bestelling.IsBetaald.ToString();
        }

        private void btnZetBetaald_Click(object sender, RoutedEventArgs e)
        {
            bestelling.ZetBetaald();
            txtBestellingsnummer.Text = bestelling.Bestellingsnummer.ToString();
            txtDatum.Text = bestelling.Datum.ToString();
            txtVerkoopprijs.Text = bestelling.VerkoopPrijs.ToString();
            txtIsBetaald.Text = bestelling.IsBetaald.ToString();
        }
    }
}
