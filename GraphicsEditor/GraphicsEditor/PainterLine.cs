using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace GraphicsEditor
{
    class PainterLine:Painter
    {
        Canvas canvas;
        Line line;
        public PainterLine(Canvas canvas)
        {
            this.canvas = canvas;
            this.line = new Line();
        }
        public override void StartDrawing(Point point)
        {
            throw new NotImplementedException();
        }

        public override void Drawing(Point point)
        {
            throw new NotImplementedException();
        }

        public override void StopDrawing(Point point)
        {
            throw new NotImplementedException();
        }

        public override void CanvasNull()
        {
            throw new NotImplementedException();
        }
    }
}
