using Itb.Core.GUI;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.MefExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
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

namespace WpfCalc3
{
    /// <summary>
    /// Interaktionslogik für App.xaml
    /// </summary>
    public partial class App : ApplicationBase
    {
        [System.STAThreadAttribute()]
        public static void Main()
        {
            var app = new App();
            app.Run();
        }

        protected override MefBootstrapper CreateBootstrapper()
        {
            return new Bootstrapper();
        }

    }

}
