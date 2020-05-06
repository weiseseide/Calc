using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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
using System.Windows.Shapes;
using WpfCalc3.ViewModels;

namespace WpfCalc3
{
    /// <summary>
    /// Interaktionslogik für Calculator.xaml
    /// </summary>
    [Export]
    public partial class MainWindow : Window
    {
        [Import(typeof(DisplayViewModel))]
        public DisplayViewModel vm 
        { 
            get { return this.DataContext as DisplayViewModel;  } /*vm;*/
            set { this.DataContext = value; } 
        }


        public MainWindow()
        {
            InitializeComponent();
        }
        
    }
}
