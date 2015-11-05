using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphicsEditor.Model
{
    class PainterPencil : Painter
     {
        Polyline pencil;
        public override void StartDrawing(Canvas canvas)
        {
            pencil = new Polyline();
            pencil.Stroke = new SolidColorBrush(MySetting.colorStrocke);
            canvas.Children.Add(pencil);
        }

        public override void Drawing(Canvas canvas)
        {
            if (pencil != null)
            {
                pencil.Points.Add( Mouse.GetPosition(canvas));
            }
        }
        public override void StopDrawing()
        {
            pencil=null;
        }
    }
}
