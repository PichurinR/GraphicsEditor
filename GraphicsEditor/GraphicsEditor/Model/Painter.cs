using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace GraphicsEditor.Model
{
    abstract class Painter
    {
        
        abstract public void StartDrawing(Canvas canvas);
        abstract public void Drawing(Canvas canvas);
        abstract public void StopDrawing();
               
    }
}
