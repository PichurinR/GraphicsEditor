using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace GraphicsEditor
{
    class PainterRectangle:Painter
    {
        Canvas canvas;
        Rectangle rectangl;
        bool flag = false;
        public PainterRectangle(Canvas canvas)
        {
            this.canvas = canvas;
        }
        public override void StartDrawing(System.Windows.Point point)
        {
            
        }

        public override void Drawing(System.Windows.Point point)
        {
            throw new NotImplementedException();
        }

        public override void StopDrawing()
        {
            throw new NotImplementedException();
        }

        public override void CanvasNull()
        {
            throw new NotImplementedException();
        }
    }
}
