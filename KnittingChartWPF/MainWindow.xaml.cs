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
                IconImage(PurlIcon(150)),
                IconImage(KnitIcon(150)),
                IconImage(YarnOver(150)),
                IconImage(K2G(150)),
                IconImage(P2G(150)),
                IconImage(SSK(150)),
                IconImage(SSP(150))
            };

            for (int i = 0; i < images.Count; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                Grid.SetColumn(images[i], i);
                grid.Children.Add(images[i]);
            }

            this.Content = grid;
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
        public Image IconImage(DrawingGroup symbolGroup)
        {
            DrawingImage drawingImageSource = new DrawingImage(symbolGroup);
            // Freeze the DrawingImage for performance benefits.
            drawingImageSource.Freeze();

            Image imageControl = new Image()
            {
                Stretch = Stretch.None,
                Source = drawingImageSource
            };
            return imageControl;
        }

        public DrawingGroup KnitIcon(double size)
        {
            DrawingGroup icon = new DrawingGroup();
            icon.Children.Add(IconBase(size));
            return icon;
        }

        public DrawingGroup PurlIcon(double size)
        {
            DrawingGroup icon = KnitIcon(size);

            GeometryDrawing purlDot =
                new GeometryDrawing(
                    new SolidColorBrush(Brushes.Black.Color),
                    new Pen(Brushes.Black, 4),
                    new EllipseGeometry(new Point(75, 75), 10, 10)
                );
            icon.Children.Add(purlDot);

            return icon;
        }

        public DrawingGroup YarnOver(double size)
        {
            DrawingGroup icon = KnitIcon(size);
            GeometryDrawing yo = new GeometryDrawing(
                    new SolidColorBrush(Brushes.White.Color),
                    new Pen(Brushes.Black, 4),
                    new EllipseGeometry(new Point(75, 75), 10, 10)
                );
            icon.Children.Add(yo);
            return icon;
        }

        public DrawingGroup K2G(double size)
        {
            DrawingGroup icon = KnitIcon(size);
            Point line1Start = new Point(3 * size / 4, size / 4);
            Point line1End = new Point(size / 4, 3 * size / 4);
            GeometryDrawing line1 = new GeometryDrawing(
                   new SolidColorBrush(Brushes.White.Color),
                   new Pen(Brushes.Black, 4),
                   new LineGeometry(line1Start, line1End)
                );
            icon.Children.Add(line1);

            Point line2Start = new Point(size / 2, size / 2);
            Point line2End = new Point(3 * size / 4, 3 * size / 4);
            GeometryDrawing line2 = new GeometryDrawing(
                   new SolidColorBrush(Brushes.White.Color),
                   new Pen(Brushes.Black, 4),
                   new LineGeometry(line2Start, line2End)
                );
            icon.Children.Add(line2);
            return icon;
        }

        public DrawingGroup P2G(double size)
        {
            DrawingGroup icon = K2G(size);
            Point bottomLineStart = new Point(.33 * size, .75* size);
            Point bottomLineEnd = new Point(.66 * size, .75* size);
            GeometryDrawing line2 = new GeometryDrawing(
                   new SolidColorBrush(Brushes.White.Color),
                   new Pen(Brushes.Black, 4),
                   new LineGeometry(bottomLineStart, bottomLineEnd)
                );
            icon.Children.Add(line2);
            return icon;
        }

        public DrawingGroup SSK(double size)
        {
            DrawingGroup icon = KnitIcon(size);
            Point line1Start = new Point(.25 * size, .25 * size);
            Point line1End = new Point(.75 * size , .75 * size);
            GeometryDrawing line1 = new GeometryDrawing(
                   new SolidColorBrush(Brushes.White.Color),
                   new Pen(Brushes.Black, 4),
                   new LineGeometry(line1Start, line1End)
                );
            icon.Children.Add(line1);

            Point line2Start = new Point(size * .5, size *.5 );
            Point line2End = new Point(size * .25, size * .75);
            GeometryDrawing line2 = new GeometryDrawing(
                   new SolidColorBrush(Brushes.White.Color),
                   new Pen(Brushes.Black, 4),
                   new LineGeometry(line2Start, line2End)
                );
            icon.Children.Add(line2);
            return icon;
        }

        public DrawingGroup SSP(double size)
        {
            var icon = SSK(size);
            Point bottomLineStart = new Point(.33 * size, .75 * size);
            Point bottomLineEnd = new Point(.66 * size, .75 * size);
            GeometryDrawing line2 = new GeometryDrawing(
                   new SolidColorBrush(Brushes.White.Color),
                   new Pen(Brushes.Black, 4),
                   new LineGeometry(bottomLineStart, bottomLineEnd)
                );
            icon.Children.Add(line2);
            return icon;
        }
    }
}
