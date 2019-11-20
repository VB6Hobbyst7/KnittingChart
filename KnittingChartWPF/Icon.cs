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
    /// Base class that icons inherit from. Protected constructor prevents instantiation
    /// </summary>
    public class Icon : Image
    {
        public DrawingGroup ComponentDrawingGroup { get; set; }
        public Stitch Stitch { get; set; }


        protected Icon(double size)
        {
            ComponentDrawingGroup = new DrawingGroup();

            GeometryDrawing rect = new GeometryDrawing(
                     new SolidColorBrush(Brushes.White.Color),
                     new Pen(Brushes.Black, 4),
                     new RectangleGeometry(new Rect(new Point(0, 0), new Point(size, size))
                 ));
            ComponentDrawingGroup.Children.Add(rect);

            Stretch = Stretch.None;
        }

        /// <summary>
        /// Sets source of Icon from ComponentDrawingGroup property
        /// </summary>
        public void SetSource()
        {
            DrawingImage drawingImageSource = new DrawingImage(ComponentDrawingGroup);
            drawingImageSource.Freeze();

            Source = drawingImageSource;
        }
    }
    public class KnitIcon : Icon
    {
        public KnitIcon(double size) : base(size)
        {
            Stitch = new KnitStitch();
            SetSource();
        }
    }
    public class PurlIcon : Icon
    {
        public PurlIcon(double size) : base(size)
        {
            Stitch = new PurlStitch();
            var drawingPosition = size / 2;
            var drawingSize = size * .1;

            GeometryDrawing purlDot =
                new GeometryDrawing(
                    new SolidColorBrush(Brushes.Black.Color),
                    new Pen(Brushes.Black, 4),
                    new EllipseGeometry(new Point(drawingPosition, drawingPosition), drawingSize, drawingSize)
                );
            ComponentDrawingGroup.Children.Add(purlDot);
            SetSource();
        }
    }
    public class YOIcon : Icon
    {
        public YOIcon(double size) : base(size)
        {
            Stitch = new YOStitch();
            var drawingPosition = size / 2;
            var drawingSize = size * .1;

            GeometryDrawing yo = new GeometryDrawing(
                    new SolidColorBrush(Brushes.White.Color),
                    new Pen(Brushes.Black, 4),
                    new EllipseGeometry(new Point(drawingPosition, drawingPosition), drawingSize, drawingSize)
                );
            ComponentDrawingGroup.Children.Add(yo);
            SetSource();
        }
    }
    public class K2GIcon : Icon
    {
        public K2GIcon(double size) : base(size)
        {
            Stitch = new K2GStitch();

            Point line1Start = new Point(.2 * size, .8 * size);
            Point line1End = new Point(.8 * size, .2 * size);
            GeometryDrawing line1 = new GeometryDrawing(
                   new SolidColorBrush(Brushes.White.Color),
                   new Pen(Brushes.Black, 4),
                   new LineGeometry(line1Start, line1End)
                );

            ComponentDrawingGroup.Children.Add(line1);
            Point line2Start = new Point(.5 * size, .5 * size);
            Point line2End = new Point(.8 * size, .8 * size);
            GeometryDrawing line2 = new GeometryDrawing(
                   new SolidColorBrush(Brushes.White.Color),
                   new Pen(Brushes.Black, 4),
                   new LineGeometry(line2Start, line2End)
                );
            ComponentDrawingGroup.Children.Add(line1);
            ComponentDrawingGroup.Children.Add(line2);
            SetSource();
        }
    }
    public class P2GIcon : Icon
    {
        public P2GIcon(double size) : base(size)
        {
            Stitch = new P2GStitch();

            Point line1Start = new Point(.2 * size, .8 * size);
            Point line1End = new Point(.8 * size, .2 * size);
            GeometryDrawing line1 = new GeometryDrawing(
                   new SolidColorBrush(Brushes.White.Color),
                   new Pen(Brushes.Black, 4),
                   new LineGeometry(line1Start, line1End)
                );

            ComponentDrawingGroup.Children.Add(line1);
            Point line2Start = new Point(.5 * size, .5 * size);
            Point line2End = new Point(.8 * size, .8 * size);
            GeometryDrawing line2 = new GeometryDrawing(
                   new SolidColorBrush(Brushes.White.Color),
                   new Pen(Brushes.Black, 4),
                   new LineGeometry(line2Start, line2End)
                );

            Point line3Start = new Point(.35 * size, .8 * size);
            Point line3End = new Point(.65 * size, .8 * size);
            GeometryDrawing line3 = new GeometryDrawing(
                   new SolidColorBrush(Brushes.White.Color),
                   new Pen(Brushes.Black, 4),
                   new LineGeometry(line3Start, line3End)
                );
            ComponentDrawingGroup.Children.Add(line1);
            ComponentDrawingGroup.Children.Add(line2);
            ComponentDrawingGroup.Children.Add(line3);

            SetSource();
        }
    }
    public class SSK : Icon
    {
        public SSK(double size) : base(size)
        {
            Stitch = new SSKStitch();
            Point line1Start = new Point(.2 * size, .2 * size);
            Point line1End = new Point(.8 * size, .8 * size);
            GeometryDrawing line1 = new GeometryDrawing(
                   new SolidColorBrush(Brushes.White.Color),
                   new Pen(Brushes.Black, 4),
                   new LineGeometry(line1Start, line1End)
                );

            ComponentDrawingGroup.Children.Add(line1);
            Point line2Start = new Point(.5 * size, .5 * size);
            Point line2End = new Point(.2 * size, .8 * size);
            GeometryDrawing line2 = new GeometryDrawing(
                   new SolidColorBrush(Brushes.White.Color),
                   new Pen(Brushes.Black, 4),
                   new LineGeometry(line2Start, line2End)
                );
            ComponentDrawingGroup.Children.Add(line1);
            ComponentDrawingGroup.Children.Add(line2);
            SetSource();
        }
    }
    public class SSP : Icon
    {
        public SSP(double size) : base(size)
        {
            Stitch = new SSPStitch();
            
            Point line1Start = new Point(.2 * size, .2 * size);
            Point line1End = new Point(.8 * size, .8 * size);
            GeometryDrawing line1 = new GeometryDrawing(
                   new SolidColorBrush(Brushes.White.Color),
                   new Pen(Brushes.Black, 4),
                   new LineGeometry(line1Start, line1End)
                );

            ComponentDrawingGroup.Children.Add(line1);
            Point line2Start = new Point(.5 * size, .5 * size);
            Point line2End = new Point(.2 * size, .8 * size);
            GeometryDrawing line2 = new GeometryDrawing(
                   new SolidColorBrush(Brushes.White.Color),
                   new Pen(Brushes.Black, 4),
                   new LineGeometry(line2Start, line2End)
                );
            Point line3Start = new Point(.35 * size, .8 * size);
            Point line3End = new Point(.65 * size, .8 * size);
            GeometryDrawing line3 = new GeometryDrawing(
                   new SolidColorBrush(Brushes.White.Color),
                   new Pen(Brushes.Black, 4),
                   new LineGeometry(line3Start, line3End)
                );

            ComponentDrawingGroup.Children.Add(line1);
            ComponentDrawingGroup.Children.Add(line2);
            ComponentDrawingGroup.Children.Add(line3);

            SetSource();
        }
    }

    public class CFIcon: Icon
    {
        public CFIcon(double size):base(size)
        {

        }
    }

}
