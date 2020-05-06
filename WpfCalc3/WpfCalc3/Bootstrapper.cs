using Itb.Core.MEF;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCalc3
{
    class Bootstrapper : BootstrapperBase
    {
        protected override void ConfigureDirectoryCatalog()
        {
            DirectoryCatalog catalog = new DirectoryCatalog(".","WpfCalc3.Determiner.dll");
            this.AggregateCatalog.Catalogs.Add(catalog);
        }
    }
}
