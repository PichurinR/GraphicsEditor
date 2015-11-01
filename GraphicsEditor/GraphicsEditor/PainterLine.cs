using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphicsEditor
{
    class PainterLine:Painter
    {
        Canvas canvas;
        Line line;
        bool flag = false;
        
        public PainterLine(Canvas canvas)
        {
            this.canvas = canvas;
        }
        public override void StartDrawing(Point point)
        {
            flag = true;
            line = new Line();
            line.Stroke = System.Windows.Media.Brushes.Blue;  //dell_____________________use colorpikker
            canvas.Children.Add(line);
            line.X1 = point.X;
            line.Y1 = point.Y;
        }

        public override void Drawing(Point point)
        {
            if (flag)
            {
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
