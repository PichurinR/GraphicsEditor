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
        BrushSettings bs;

        public MainWindow()
        {
            InitializeComponent();
            bs = new BrushSettings();
            toolPencil_Click(new object(), new RoutedEventArgs());
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "BMP files (*.bmp)|*.bmp";
            openFileDialog.RestoreDirectory = true;     //Востанавливать ранее отркытый путь к файлу
            if (openFileDialog.ShowDialog() == true)
            {
                ImageBrush img = new ImageBrush();
                img.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Relative));
                myCanvas.Background = img;
            }
        }

        private void saveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.FileName = "MyPicture";      // Имя по умолчанию
            saveFileDialog.Filter = "BMP files (*.bmp)|*.bmp";
            saveFileDialog.ShowDialog();
            util.SaveCanvas(myCanvas, 96, saveFileDialog.FileName);
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {

            
        }

     public System.Drawing.Bitmap Invert(System.Drawing.Bitmap bitmap)
            {
                //X Axis
                int x;
                //Y Axis
                int y;
                //For the Width
                for (x = 0; x <= bitmap.Width - 1; x++)
                {
                    //For the Height
                    for (y = 0; y <= bitmap.Height - 1; y += 1)
                    {
                        //The Old Color to Replace
                        System.Drawing.Color oldColor = bitmap.GetPixel(x, y);
                        //The New Color to Replace the Old Color
                        System.Drawing.Color newColor;
                        //Set the Color for newColor
                        newColor = System.Drawing.Color.FromArgb(oldColor.A, 255 - oldColor.R, 255 - oldColor.G, 255 - oldColor.B);
                        //Replace the Old Color with the New Color
                        bitmap.SetPixel(x, y, newColor);
                    }
                }
                //Return the Inverted Bitmap
                return bitmap;
            }

        public static class util
        {
            public static void SaveCanvas(Canvas canvas, int dpi, string filename)
            {

                Rect rect = new Rect(canvas.Margin.Left, canvas.Margin.Top, canvas.ActualWidth, canvas.ActualHeight);   //Получаем ширину и высоту нашего будущего изображения(квадрата)

                RenderTargetBitmap rtb = new RenderTargetBitmap((int)rect.Right, (int)rect.Bottom, dpi, dpi, System.Windows.Media.PixelFormats.Default); // через  обьект класса RenderTargetBitmap будем преобразовывать canvas в растровое изображение

                rtb.Render(canvas);

                BitmapEncoder pngEncoder = new BmpBitmapEncoder(); // опредиляем кодировщик, для кодирования изображения
                pngEncoder.Frames.Add(BitmapFrame.Create(rtb)); // задайом фрейм для изображения

                try
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(); //Создаем поток в память.

                    pngEncoder.Save(ms);  // кодируем изображение в наш поток
                    ms.Close();          //Закрываем поток

                    System.IO.File.WriteAllBytes(filename, ms.ToArray()); // Создаем файл, записываем в него масив байтов и закрываем
                }
                catch (Exception err)
                {
                    System.Windows.MessageBox.Show(err.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }


        }

    }
}