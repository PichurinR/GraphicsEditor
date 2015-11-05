using System;
using System.Text;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;

namespace GraphicsEditor.Model
{
    class PainterRectangle:Painter
    {
        Rectangle rectangl;
        Point startPoint;

        public override void StartDrawing(Canvas canvas)
        {
            rectangl = new Rectangle();
            rectangl.Stroke = new SolidColorBrush(MySetting.colorStrocke);
            rectangl.Fill = new SolidColorBrush(MySetting.colorFill);
            canvas.Children.Add(rectangl);
            startPoint = Mouse.GetPosition(canvas);
        }

        public override void Drawing(Canvas canvas)
        {
            if (rectangl != null)
            {
                Point pos = Mouse.GetPosition(canvas);

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
            rectangl = null;
        }

    }
}
