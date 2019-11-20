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

namespace KnittingChartWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Grid grid = new Grid();
            grid.HorizontalAlignment = HorizontalAlignment.Center;
            grid.VerticalAlignment = VerticalAlignment.Center;
            grid.Background = new SolidColorBrush(Colors.LightSteelBlue);

            List<Image> images = new List<Image>()
            {
                new KnitIcon(150),
                new PurlIcon(150),
                new YOIcon(150),
                new K2GIcon(150),
                new P2GIcon(150),
                new SSK(150),
                new SSP(150),
            };

            for (int i = 0; i < images.Count; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                Grid.SetColumn(images[i], i);
                grid.Children.Add(images[i]);
            }

            this.Content = grid;
        }




    }
}
