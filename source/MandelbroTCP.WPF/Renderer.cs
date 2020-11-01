namespace MandelbroTCP.WPF
{
    using System;
    using System.Linq;
    using System.Numerics;
    using System.Windows;
    using System.Windows.Media;

    public class Renderer : FrameworkElement
    {
        public MainWindow MainWindow { get; set; }

        protected override void OnRender(DrawingContext drawingContext)
        {

            drawingContext.DrawRectangle(Brushes.Black, null,
                new Rect(0, 0, MainWindow.ImageWidth, MainWindow.ImageHeight));
        }
    }
}
