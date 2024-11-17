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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MasterMind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] kleurenArray = {"Rood", "Geel", "Oranje", "Wit", "Groen", "Blauw"};
        string[] code;
        Dictionary<string, SolidColorBrush> kleurenDictionary = new Dictionary<string, SolidColorBrush> { 
            { "Rood", new SolidColorBrush(Colors.Red) }, 
            { "Geel", new SolidColorBrush(Colors.Yellow) },
            { "Oranje", new SolidColorBrush(Colors.Orange) },
            { "Wit", new SolidColorBrush(Colors.White) },
            { "Groen", new SolidColorBrush(Colors.Green) },
            { "Blauw", new SolidColorBrush(Colors.Blue) },
        };

        public MainWindow()
        {
            InitializeComponent();
            GenereerCode();
            VulCbo();
        }
        public void GenereerCode()
        {
            code = new string[4];
            Random random = new Random();
            int i = 0;
            List<int> alGebruikteRngs = new List<int>();

            while (i<4) 
            {
                int rng = random.Next(0, kleurenArray.Length);
                
                if (!alGebruikteRngs.Contains(rng))
                {
                    code[i] = kleurenArray[rng];
                    alGebruikteRngs.Add(rng);
                    i++;
                }
            }
           
            this.Title = $"MasterMind({string.Join(",", code)})";
        }
        public void VulCbo()
        {
            int i = 0;
            while (i < kleurenArray.Length)
            {
                Cbo1.Items.Add(kleurenArray[i]);
                Cbo2.Items.Add(kleurenArray[i]);
                Cbo3.Items.Add(kleurenArray[i]);
                Cbo4.Items.Add(kleurenArray[i]);
                i++;
            }
        }


        private void Cbo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Cbo1.SelectedIndex != -1)
            {
                string geselecteerdeKleur = Cbo1.SelectedItem.ToString();
                Lbl1.Background = kleurenDictionary[geselecteerdeKleur];
            }
        }

        private void Cbo2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cbo2.SelectedIndex != -1)
            {
                string geselecteerdeKleur = Cbo2.SelectedItem.ToString();
                Lbl2.Background = kleurenDictionary[geselecteerdeKleur];
            }
        }

        private void Cbo3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cbo3.SelectedIndex != -1)
            {
                string geselecteerdeKleur = Cbo3.SelectedItem.ToString();
                Lbl3.Background = kleurenDictionary[geselecteerdeKleur];
            }
        }

        private void Cbo4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cbo4.SelectedIndex != -1)
            {
                string geselecteerdeKleur = Cbo4.SelectedItem.ToString();
                Lbl4.Background = kleurenDictionary[geselecteerdeKleur];
            }
        }
    }
}