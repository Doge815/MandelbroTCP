namespace MandelbroTCP.WPF
{
    using System;
    using System.Linq;
    using System.Numerics;
    using System.Windows;
    using System.Windows.Media;
    using MandelbroTCP.Base;
    using MandelbroTCP.Server.Calc;

    public class Renderer : FrameworkElement
    {
        public MainWindow MainWindow { get; set; }

        protected override void OnRender(DrawingContext drawingContext)
        {
            BrotInfo vals = new BrotInfo();
            vals.PosX = -0.5;
            vals.PosY = 0;
            vals.Precision = 15;
            vals.Zoom = 1;
            vals.SizeX = MainWindow.ImageWidth;
            vals.SizeY = MainWindow.ImageHeight;

            //temporary serverless calculation
            PixelCollection brot = Brot.GetBrot(vals);

            for (int x = 0; x < MainWindow.ImageWidth; x++)
            {
                for (int y = 0; y < MainWindow.ImageHeight; y++)
                {
                    Brush b = (brot.GetColors()[x, y] == new Base.Color() { Red = 0, Green = 0, Blue = 0 }) ? (Brushes.Black) : (Brushes.White);
                    drawingContext.DrawRectangle(b, null,
                        new Rect(x, y, 1, 1));
                }
            }


        }
    }
}
