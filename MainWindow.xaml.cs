using System.Windows;

namespace Sharp01ButenkoAnton
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new BDViewModel();
        }
    }
}
