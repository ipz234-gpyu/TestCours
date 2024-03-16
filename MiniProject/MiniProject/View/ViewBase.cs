using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MiniProject
{
    public abstract class ViewBase : UserControl
    {
        public ViewBase()
        {
            this.Loaded += ViewBase_Loaded;
        }

        protected abstract void Initialize();

        protected virtual void ViewBase_Loaded(object sender, RoutedEventArgs e)
        {
            Initialize();
        }
    }
}
