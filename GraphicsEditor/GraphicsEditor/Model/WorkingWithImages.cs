using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GraphicsEditor.Model
{
    class WorkingWithImages
    {
        Canvas canvas;

        public WorkingWithImages(Canvas canvas)
        {
            this.canvas = canvas;
        }

        public void OpenImages()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "BMP files (*.bmp)|*.bmp";
            openFileDialog.RestoreDirectory = true;     //Востанавливать ранее отркытый путь к файлу
            if (openFileDialog.ShowDialog() == true)
            {
                ImageBrush img = new ImageBrush();
                img.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Relative));
                if (canvas.Children.Count>0) canvas.Children.Clear();
                canvas.Background = img;
            }
        }
        public  void SaveImage()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.FileName = "Picture_"+DateTime.Now;      // Имя по умолчанию
            saveFileDialog.Filter = "BMP files (*.bmp)|*.bmp";
            saveFileDialog.ShowDialog();
            RenderTargetBitmap rtb = CanvasToBitmap();
            BitmapEncoder bmpEncoder = new BmpBitmapEncoder();  // опредиляем кодировщик, для кодирования изображения
            bmpEncoder.Frames.Add(BitmapFrame.Create(rtb));     // задайом фрейм для изображения
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream(); //Создаем поток в память.
                bmpEncoder.Save(ms);         // кодируем изображение в наш поток
                ms.Close();                 
                System.IO.File.WriteAllBytes(saveFileDialog.FileName, ms.ToArray()); // Создаем файл, записываем в него масив байтов и закрываем
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        RenderTargetBitmap CanvasToBitmap()
        {
            Size size = new Size(canvas.ActualWidth, canvas.ActualHeight);
            canvas.Measure(size);
            Rect rect = new Rect(size);   //Получаем ширину и высоту нашего будущего изображения(квадрата)
            canvas.Arrange(rect);
            int dpi = 96;
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)size.Width, (int)size.Height, dpi, dpi, System.Windows.Media.PixelFormats.Default); // через  обьект класса RenderTargetBitmap будем преобразовывать canvas в растровое изображение
            rtb.Render(canvas);
            return rtb;
        }

    }
}
