using GraphicsEditor.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace GraphicsEditor.Controller
{
    class ProgControll
    {
        Painter painter; 
        WorkingWithImages workImg; //Класс для работы с файлами.
        Canvas canvas;
        ProgressBar progresBar;

        public ProgControll(Canvas canvas, ProgressBar progresBar)
        {
            this.canvas = canvas;
            this.progresBar = progresBar;
            workImg = new WorkingWithImages(canvas, progresBar);
        }

        public void OpenFile()
        {
            workImg.OpenImages();
        }
        public void SaveFile()
        {
            workImg.SaveImage();
        }
        public void ClearCanvas()
        {
            workImg.ClearCanvas();
        }
        public void EditImg()
        {
            if (workImg.IsInvertWork) System.Windows.MessageBox.Show("Background proccess Invert is active! Wait for the end!");
            else workImg.InvertImage();
        }

        public void StartDrawing()
        {
            if (painter!=null)
	        {
                painter.StartDrawing(canvas);
	        }
        }
        public void Drawing()
        {
            if (painter != null)
            {
                painter.Drawing(canvas);
            }
        }
        public void StopDrawing()
        {
            if (painter != null)
            {
                painter.StopDrawing();
            }
        }

        public void SetPaintBrush(string tag)
        {
            switch (tag)
            {
                case "Pencil":
                    painter = new PainterPencil();
                    break;
                case "Line":
                    painter = new PainterLine();
                    break;
                case "Rectangle":
                    painter = new PainterRectangle();
                    break;
                case "Circle":
                    painter = new PainterCircle();
                    break;
            }
        }
    }
}
