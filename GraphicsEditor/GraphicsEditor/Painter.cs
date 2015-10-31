using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GraphicsEditor
{
    abstract class Painter
    {
        abstract public void StartDrawing();
        abstract public void Drawing();
        abstract public void StopDrawing();
        abstract public void CanvasNull();
    }
}
