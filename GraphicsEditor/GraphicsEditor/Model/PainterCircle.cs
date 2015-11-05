using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphicsEditor.Model
{
    class PainterCircle : Painter
    {
        Ellipse circle;
        Point startPoint;

        public override void StartDrawing(Canvas canvas)
        {
            circle = new Ellipse();
            circle.Stroke = new SolidColorBrush(MySetting.colorStrocke);
            circle.Fill = new SolidColorBrush(MySetting.colorFill);
            canvas.Children.Add(circle);
            startPoint = Mouse.GetPosition(canvas);
        }

        public override void Drawing(Canvas canvas)
        {
            if (circle!=null)
            {
                Point pos = Mouse.GetPosition(canvas);

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
            circle = null;
        }
       
    }
}
