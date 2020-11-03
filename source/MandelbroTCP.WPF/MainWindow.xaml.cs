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

namespace MandelbroTCP.WPF
{
    public partial class MainWindow : Window
    {
        public uint ImageWidth { get; set; } = 800;
        public uint ImageHeight { get; set; } = 800;
        public MainWindow()
        {
            InitializeComponent();
            Renderer.MainWindow = this;
            Renderer.InvalidateVisual();
        }
    }
}
