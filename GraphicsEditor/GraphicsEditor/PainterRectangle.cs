using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Media;

namespace GraphicsEditor
{
    class PainterRectangle:Painter
    {
        Canvas canvas;
        Rectangle rectangl;
        bool flag = false;
        Point startPoint;

        public PainterRectangle(Canvas canvas)
        {
            this.canvas = canvas;
        }
        public override void StartDrawing(Point point, BrushSettings bs)
        {
            flag = true;
            rectangl = new Rectangle();
            rectangl.Stroke = new SolidColorBrush(bs.colorStrocke);
            rectangl.Fill= new SolidColorBrush(bs.colorFill);
            canvas.Children.Add(rectangl);
            startPoint = point;
        }

        public override void Drawing(Point point)
        {
            if (flag)
            {
                Point pos = point;

                double x = Math.Min(pos.X, startPoint.X);
                double y = Math.Min(pos.Y, startPoint.Y);

                double w = Math.Max(pos.X, startPoint.X) - x;
                double h = Math.Max(pos.Y, startPoint.Y) - y;

                rectangl.Width = w;
                rectangl.Height = h;

                Canvas.SetLeft(rectangl, x);
                Canvas.SetTop(rectangl, y);
            }
        }

        public override void StopDrawing()
        {
            flag = false;
        }

        public override void CanvasNull()
        {
           
        }
    }
}
