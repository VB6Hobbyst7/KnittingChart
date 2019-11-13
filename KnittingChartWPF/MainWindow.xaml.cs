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

            //FileInfo fileInfo = new FileInfo(purlUri.AbsolutePath);
            //FileInfo x = new FileInfo(@"C:\Users\linma\source\repos\KnittingChartWPF\icons\purl.svg");
            //DirectoryInfo icons = new DirectoryInfo(@"C:\Users\linma\source\repos\KnittingChartWPF\icons\");
            //var files = icons.GetFiles();
            //FileInfo purlIcon = files[0];
            //var exists = x.Exists;
            //Grid grid = new Grid();

            var h = this.ActualHeight;

            // Create the Grid

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

            RowDefinition x = dynamicGrid.RowDefinitions.Last();

            var iconList = new List<Rectangle>();
            for (int i = 0; i < 3; i++)
            {
                iconList.Add(IconBase(50));
            }


            DataGrid dataGrid = new DataGrid();
            dataGrid.ItemsSource = iconList;
            var drawing = PurlIcon();


            DrawingGroup imageDrawings = new DrawingGroup();

            // Create a 100 by 100 image with an upper-left point of (75,75). 



            // Create a 25 by 25 image with an upper-left point of (0,150). 


            //
            // Use a DrawingImage and an Image control to
            // display the drawings.
            //
            DrawingImage drawingImageSource = new DrawingImage(PurlIcon());

            // Freeze the DrawingImage for performance benefits.
            drawingImageSource.Freeze();

            Image imageControl = new Image();
            imageControl.Stretch = Stretch.None;
            imageControl.Source = drawingImageSource;

            // Create a border to contain the Image control.
            Border imageBorder = new Border();
            imageBorder.BorderBrush = Brushes.Gray;
            imageBorder.BorderThickness = new Thickness(1);
            imageBorder.HorizontalAlignment = HorizontalAlignment.Left;
            imageBorder.VerticalAlignment = VerticalAlignment.Top;
            imageBorder.Margin = new Thickness(20);
            imageBorder.Child = imageControl;

            this.Background = Brushes.White;
            this.Margin = new Thickness(20);
            this.Content = imageBorder;

        }

        public Rectangle IconBase(double size)
        {
            SolidColorBrush fillColor = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            SolidColorBrush strokeColor = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            var box = new Rectangle()
            {
                Fill = fillColor,
                Stroke = strokeColor,
                Height = size,
                Width = size
            };
            return box;
        }

        public DrawingGroup PurlIcon()
        {
            GeometryDrawing rect = new GeometryDrawing(
                    new SolidColorBrush(Brushes.White.Color),
                    new Pen(Brushes.Black, 4),
                    new RectangleGeometry(new Rect(new Point(0, 0), new Point(150, 150))
                ));

            GeometryDrawing ellipseDrawing =
                new GeometryDrawing(
                    new SolidColorBrush(Brushes.Black.Color),
                    new Pen(Brushes.Black, 4),
                    new EllipseGeometry(new Point(75, 75), 10, 10)
                );

            // Create a DrawingGroup to contain the drawings.
            DrawingGroup aDrawingGroup = new DrawingGroup();
            aDrawingGroup.Children.Add(rect);
            aDrawingGroup.Children.Add(ellipseDrawing);
            return aDrawingGroup;
        }
    }
}
