using System;
using System.Collections.Generic;
using System.Linq;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        Painter painter;
        
        private void toolPencil_Click(object sender, RoutedEventArgs e)
        {
            painter = new PainterPencil(myCanvas, strokeColorPick.SelectedColor.Value);
            
        }

        private void toolLine_Click(object sender, RoutedEventArgs e)
        {
            painter = new PainterLine(myCanvas);        
        }

        private void toolRectangle_Click(object sender, RoutedEventArgs e)
        {
            painter = new PainterRectangle(myCanvas);
        }

        private void toolCircle_Click(object sender, RoutedEventArgs e)
        {
            painter = new PainterCircle(myCanvas);
        }

        private void myCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (painter!=null)
            {
                painter.StartDrawing(new Point(e.GetPosition(myCanvas).X, e.GetPosition(myCanvas).Y));
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
        }
              
    }
}
