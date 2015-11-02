using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphicsEditor
{
    class PainterPencil : Painter
     {
        Canvas canvas;
        Polyline pencil;
        bool flag = false;
        PointCollection pointCollect;
        public PainterPencil(Canvas canvas)
        {
            this.canvas = canvas;
        }

        
        public override void StartDrawing(Point point,BrushSettings bs)
        {
            flag = true;
            pencil = new Polyline();
            pencil.Stroke = new SolidColorBrush(bs.colorStrocke);
            canvas.Children.Add(pencil);
            pointCollect = new PointCollection();
            pointCollect.Add(point);
        }

        public override void Drawing(Point point)
        {
            if (flag)
            {
                pointCollect.Add(point);
                pencil.Points = pointCollect;
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
