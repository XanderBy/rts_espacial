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

namespace rts_espacial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        JuegoLibreria.Principal.Juego juego = new JuegoLibreria.Principal.Juego(600, 600);
        public MainWindow()
        {
            InitializeComponent();
            this.Width = juego.AnchoPantalla;
            this.Height = juego.AltoPantalla;
        }
    }
}
