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
            Stitch = new Stitch();

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
            Name = "Knit";
            Stitch.StitchKey = "K";
            Stitch.Description = "Just a knit stitch";
            SetSource();
        }
    }
    public class PurlIcon : Icon
    {
        public PurlIcon(double size) : base(size)
        {
            Stitch.StitchName = "Purl";
            Stitch.StitchKey = "P";
            Stitch.Description = "How are you using this chart if you don't know how to purl?";

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
            Stitch.StitchKey = "YO";
            Stitch.StitchName = "Yarn Over";
            Stitch.Description = "Just drap the yarn over the needle once";
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
            Stitch.StitchName = "Knit 2 Together";
            Stitch.StitchKey = "K2G";
            Stitch.Description = "Make a knit stitch through two stitches at a time";

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
            Stitch.Description = "Purl through two stitches at a time";
            Stitch.StitchKey = "P2G";
            Stitch.StitchName = "Purl 2 Together";

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
            Stitch.StitchName = "Slip slip knit";
            Stitch.StitchKey = "SSK";
            Stitch.Description = "Slip two stitches purlwise; put stitches back on left needles; knit both stitches through the back loop";

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

            Stitch.StitchName = "Slip slip purl";
            Stitch.StitchKey = "SSP";
            Stitch.Description = "Slip two stitches purlwise; put stitches back on left needle; purl 2 stitches through back loop";

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


}
