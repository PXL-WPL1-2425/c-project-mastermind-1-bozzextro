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
        string[] kleuren = {"Rood", "Geel", "Oranje", "Wit", "Groen", "Blauw"};
        string[] code;

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
                int rng = random.Next(0, kleuren.Length);
                
                if (!alGebruikteRngs.Contains(rng))
                {
                    code[i] = kleuren[rng];
                    alGebruikteRngs.Add(rng);
                    i++;
                }
            }
           
            this.Title = $"MasterMind({string.Join(",", code)})";
        }
        public void VulCbo()
        {
            int i = 0;
            while (i < kleuren.Length)
            {
                Cbo1.Items.Add(kleuren[i]);
                Cbo2.Items.Add(kleuren[i]);
                Cbo3.Items.Add(kleuren[i]);
                Cbo4.Items.Add(kleuren[i]);
                i++;
            }
        }
    }
}