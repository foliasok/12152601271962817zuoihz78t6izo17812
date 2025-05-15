using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace celloveszetWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Lovesz> lovesek = new List<Lovesz>();
        public MainWindow()
        {
            InitializeComponent();
            string[] fajl = File.ReadAllLines("lovesek.csv");
            foreach (var sor in fajl)
            {
                lovesek.Add(new Lovesz(sor));
            }
            adatok.ItemsSource = lovesek;
        }

        private void Hozzaad(object sender, RoutedEventArgs e)
        {
            if(nev.Text != "" && loves1.Text != "" && loves2.Text != "" && loves3.Text != "" && loves4.Text != "")
            {
                if (0 <= int.Parse(loves1.Text) && int.Parse(loves1.Text) <= 99 && 0 <= int.Parse(loves2.Text) && int.Parse(loves2.Text) <= 99 && 0 <= int.Parse(loves3.Text) && int.Parse(loves3.Text) <= 99 && 0 <= int.Parse(loves4.Text) && int.Parse(loves4.Text) <= 99)
                {
                    lovesek.Add(new Lovesz($"{nev.Text};{loves1.Text};{loves2.Text};{loves3.Text};{loves4.Text}"));
                    adatok.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("Nem megfelelő értékek");
                }
            }
            else
            {
                MessageBox.Show("Minden mezőt kikell tölteni!");
            }
        }

        private void Mentes(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("lovesek2.csv");
            foreach (var l in lovesek)
            {
                sw.WriteLine($"{l.Nev};{l.ElsoLoves};{l.MasodikLoves};{l.HarmadikLoves};{l.NegyedikLoves}");
            }
            sw.Close();
            MessageBox.Show("A mentés sikeresen megtörtént!");
        }
    }
}