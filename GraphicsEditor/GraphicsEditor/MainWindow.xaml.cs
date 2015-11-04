using GraphicsEditor.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;


namespace GraphicsEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Painter painter;
        Settings bs;
        WorkingWithImages wImg;
        public MainWindow()
        {
            InitializeComponent();
            bs = new Settings();
            toolPencil_Click(new object(), new RoutedEventArgs());
            wImg = new WorkingWithImages(myCanvas);
        }



        private void toolPencil_Click(object sender, RoutedEventArgs e)
        {
            painter = new PainterPencil(myCanvas);
            fillColorPick.IsEnabled = false;
        }

        private void toolLine_Click(object sender, RoutedEventArgs e)
        {
            painter = new PainterLine(myCanvas);
            fillColorPick.IsEnabled = false;
        }

        private void toolRectangle_Click(object sender, RoutedEventArgs e)
        {
            painter = new PainterRectangle(myCanvas);
            fillColorPick.IsEnabled = true;
        }

        private void toolCircle_Click(object sender, RoutedEventArgs e)
        {
            painter = new PainterCircle(myCanvas);
            fillColorPick.IsEnabled = true;
        }

        private void myCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (painter != null)
            {
                bs.colorStrocke = strokeColorPick.SelectedColor.Value;
                bs.colorFill = fillColorPick.SelectedColor.Value;
                painter.StartDrawing(new Point(e.GetPosition(myCanvas).X, e.GetPosition(myCanvas).Y), bs);
            }
        }

        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (painter != null)
            {
                painter.Drawing(new Point(e.GetPosition(myCanvas).X, e.GetPosition(myCanvas).Y));
            }
        }

        private void myCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (painter != null)
            {
                painter.StopDrawing();
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.Children.Clear();
            myCanvas.Background = Brushes.White;
        }

        private void openFile_Click(object sender, RoutedEventArgs e)
        {
            wImg.OpenImages();
        }

        private void saveFile_Click(object sender, RoutedEventArgs e)
        {
            wImg.SaveImage();
           
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            wImg.InvertImage();   
        }

     
    }
}