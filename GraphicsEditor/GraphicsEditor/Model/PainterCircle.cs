using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphicsEditor.Model
{
    class PainterCircle : Painter
    {
       
        Canvas canvas;
        Ellipse circle;
        bool flag = false;
        Point startPoint;
      
        public PainterCircle(Canvas canvas)
        {
            this.canvas = canvas;

        }

        public override void StartDrawing(Point point,Settings bs)
        {
            flag = true;
            circle = new Ellipse();
            circle.Stroke = new SolidColorBrush(bs.colorStrocke);
            circle.Fill = new SolidColorBrush(bs.colorFill);
            canvas.Children.Add(circle);
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

                circle.Width = w;
                circle.Height = h;

                Canvas.SetLeft(circle, x);
                Canvas.SetTop(circle, y);
            }
        }
         
        public override void StopDrawing()
        {
            flag = false;
        }
        public override void CanvasNull()
        {
            throw new NotImplementedException();
        }
    }
}
