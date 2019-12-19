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

namespace WebsiteAuswertungWPF
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal IOC ioc = new IOC();
        public MainWindow()
        {
            InitializeComponent();
            ioc.DB.Start_DB_Connection();
        }

        private void ImagePanel_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                ioc.Files.Files(files[0]);
                btn_DB.IsEnabled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ioc.Insert_DB();
        }

        private void btn_Stats_Click(object sender, RoutedEventArgs e)
        {
            ioc.Sort.Sort();
            ioc.Top();
            double[] x = new double[10];
            double[] y = new double[10];
            if (ioc.Sort.domains.Count >= 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    x[i] += i * 10;
                    y[i] += ioc.Sort.domains[i].Count;
                    Console.WriteLine("Test " + i);
                }
                string[] labels = { ioc.Sort.domains[0].Name, ioc.Sort.domains[1].Name, ioc.Sort.domains[2].Name, ioc.Sort.domains[3].Name, ioc.Sort.domains[4].Name, ioc.Sort.domains[5].Name, ioc.Sort.domains[6].Name, ioc.Sort.domains[7].Name, ioc.Sort.domains[8].Name, ioc.Sort.domains[9].Name };
                plt_Auswertung.plt.PlotBar(x, y);
                plt_Auswertung.Render();
            }
        }

        private void btn_DB_Load_Click(object sender, RoutedEventArgs e)
        {
            ioc.LoadData();
        }
    }
}
