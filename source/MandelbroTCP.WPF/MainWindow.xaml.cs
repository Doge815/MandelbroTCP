namespace MandelbroTCP.WPF
{
    using System;
    using System.Numerics;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Threading;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public DrawingImage Bitmap { get; set; }

        public uint ImageWidth { get; } = 800;
        public uint ImageHeight { get; } = 800;

        public MainWindow()
        {
            InitializeComponent();
            Renderer.MainWindow = this;
            Renderer.InvalidateVisual();
        } 
    }
}
