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
            Grid dynamicGrid = new Grid();
            dynamicGrid.Width = 400;
            dynamicGrid.Height = Height;
            dynamicGrid.HorizontalAlignment = HorizontalAlignment.Center;
            dynamicGrid.VerticalAlignment = VerticalAlignment.Center;
            dynamicGrid.ShowGridLines = true;
            dynamicGrid.Background = new SolidColorBrush(Colors.LightSteelBlue);

            // create columns
            for (int i = 0; i < 3; i++)
            {
                dynamicGrid.ColumnDefinitions.Add(new ColumnDefinition());
                dynamicGrid.RowDefinitions.Add(new RowDefinition());
            }
        }

        public GeometryDrawing IconBase(double size)
        {
            GeometryDrawing rect = new GeometryDrawing(
                new SolidColorBrush(Brushes.White.Color),
                new Pen(Brushes.Black, 4),
                new RectangleGeometry(new Rect(new Point(0, 0), new Point(size, size))
            ));

            return rect;
        }

        public DrawingGroup PurlIcon()
        {
            DrawingGroup aDrawingGroup = new DrawingGroup();
            aDrawingGroup.Children.Add(IconBase(150));

            GeometryDrawing purlDot =
                new GeometryDrawing(
                    new SolidColorBrush(Brushes.Black.Color),
                    new Pen(Brushes.Black, 4),
                    new EllipseGeometry(new Point(75, 75), 10, 10)
                );
            aDrawingGroup.Children.Add(purlDot);

            return aDrawingGroup;
        }

        public Image KnittingIcon()
        {
            DrawingImage drawingImageSource = new DrawingImage(PurlIcon());
            // Freeze the DrawingImage for performance benefits.
            drawingImageSource.Freeze();


            Image imageControl = new Image()
            {
                Stretch = Stretch.None,
                Source = drawingImageSource
            };
            return imageControl;
        }
    }
}
