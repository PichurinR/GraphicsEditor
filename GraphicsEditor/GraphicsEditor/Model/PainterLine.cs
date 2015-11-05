using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphicsEditor.Model
{
    class PainterLine:Painter
    {
        
        Line line;
        Point temp;
        public override void StartDrawing(Canvas canvas)
        {
            
            line = new Line();
            temp = Mouse.GetPosition(canvas);
            line.Stroke = new SolidColorBrush(MySetting.colorStrocke);
            canvas.Children.Add(line);
           
        }

        public override void Drawing(Canvas canvas)
        {
           
            if (line !=null)
            {
                line.X1 = temp.X;
                line.Y1 = temp.Y;
                line.X2 = Mouse.GetPosition(canvas).X;
                line.Y2 = Mouse.GetPosition(canvas).Y;
            }
        }

        public override void StopDrawing()
        {
            line = null;
        }
        
    }
}
