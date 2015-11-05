using GraphicsEditor.Controller;
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
        
        
        ProgControll controller;
        public MainWindow()
        {
            InitializeComponent();
            MySetting.colorStrocke = strokeColorPick.SelectedColor.Value;
            MySetting.colorFill = fillColorPick.SelectedColor.Value;
            controller = new ProgControll(myCanvas, progresBar);
           
        }



        private void tool_Click(object sender, RoutedEventArgs e)
        {
            controller.SetPaintBrush(((Button)sender).Tag.ToString());
        }
          
        private void myCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            controller.StartDrawing();               
        }

        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            controller.Drawing();
        }

        private void myCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            controller.StopDrawing();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            controller.ClearCanvas();
        }

        private void openFile_Click(object sender, RoutedEventArgs e)
        {
            controller.OpenFile();
        }

        private void saveFile_Click(object sender, RoutedEventArgs e)
        {
            controller.SaveFile();           
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            controller.EditImg();            
        }

        private void strokeColorPick_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            MySetting.colorStrocke = strokeColorPick.SelectedColor.Value;
        }

        private void fillColorPick_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            MySetting.colorFill = fillColorPick.SelectedColor.Value;
        }

        
     
    }
}