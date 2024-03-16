using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.ComponentModel;

namespace WpfAppTest.View
{
    public abstract class ViewAbstract : UserControl
    {
        public ViewAbstract() =>
            this.Loaded += ViewBase_Loaded;

        protected abstract void Initialize();

        protected virtual void ViewBase_Loaded(object sender, RoutedEventArgs e) =>
            Initialize();
    }
}
