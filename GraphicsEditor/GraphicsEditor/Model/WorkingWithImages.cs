using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        BackgroundWorker bckGrWorker;
        public WorkingWithImages(Canvas canvas)
        {
            this.canvas = canvas;
            bckGrWorker = new BackgroundWorker();
            bckGrWorker.WorkerReportsProgress = true;   //Поддерж. обновление сведений о ходе выполнения.
            bckGrWorker.DoWork += bckGrWorker_DoWork;
            bckGrWorker.RunWorkerCompleted += bckGrWorker_RunWorkerCompleted;
            bckGrWorker.ProgressChanged += bckGrWorker_ProgressChanged;
        }

        void bckGrWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        void bckGrWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null && e.Result is System.Drawing.Bitmap)
            {
                BitmapImage image;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())        //Бит
                {
                    ((System.Drawing.Bitmap)e.Result).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    ms.Position = 0;
                    image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = ms;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.EndInit();
                }
                canvas.Children.Clear();
                canvas.Background = new ImageBrush(image);
            }
            
        }

        void bckGrWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument is System.Drawing.Bitmap)
            {
               e.Result=InvertMethod((System.Drawing.Bitmap)e.Argument);
            }
            
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
            saveFileDialog.FileName = "Picture_"+DateTime.Now.GetHashCode();      // Имя по умолчанию
            saveFileDialog.Filter = "BMP files (*.bmp)|*.bmp";
            saveFileDialog.ShowDialog();
            
            Thickness margin = canvas.Margin;
            canvas.Margin = new Thickness(0);
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
            canvas.Margin = margin;
        }

        public void InvertImage()
        {
            Thickness margin = canvas.Margin;
            canvas.Margin = new Thickness(0);
            RenderTargetBitmap rtb = CanvasToBitmap();
            canvas.Margin = margin;
            System.Drawing.Bitmap bitmap;
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream(); //Создаем поток в память.
                BitmapEncoder bmpEncoder = new BmpBitmapEncoder();
                bmpEncoder.Frames.Add(BitmapFrame.Create(rtb));
                bmpEncoder.Save(ms);
                bitmap = new System.Drawing.Bitmap(ms);
                ms.Close();
                bckGrWorker.RunWorkerAsync(bitmap);
                
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

        System.Drawing.Bitmap InvertMethod(System.Drawing.Bitmap bitmap)
        {

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y <bitmap.Height ; y++)
                {
                    System.Drawing.Color oldColor = bitmap.GetPixel(x,y);
                    System.Drawing.Color newColor;
                    newColor = System.Drawing.Color.FromArgb(oldColor.A, 255 - oldColor.R, 255 - oldColor.G, 255 - oldColor.B);
                    bitmap.SetPixel(x, y, newColor);
                }
                System.Threading.Thread.Sleep(5);
            }
          
            return bitmap;
        }

    }
}
