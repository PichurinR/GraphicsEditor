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
    class PainterLine:Painter
    {
        Canvas canvas;
        Line line;
        bool flag = false;
        Point temp;
        public PainterLine(Canvas canvas)
        {
            this.canvas = canvas;
        }
        public override void StartDrawing(Point point,BrushSettings bs)
        {
            flag = true;
            line = new Line();
            temp = point;
            line.Stroke = new SolidColorBrush(bs.colorStrocke);
            canvas.Children.Add(line);
           
        }

        public override void Drawing(Point point)
        {
           
            if (flag)
            {
                line.X1 = temp.X;
                line.Y1 = temp.Y;
                line.X2 = point.X;
                line.Y2 = point.Y;
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
