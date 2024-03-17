using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using WpfAppTest.View;

namespace WpfAppTest
{
    public class ViewEnemy : ViewAbstract
    {
        public Border _borderEnemy;
        public Grid _parentPanel;

        public ViewEnemy(Grid parentPanel) : base()
        {
            _parentPanel = parentPanel;
            Initialize();
        }

        protected override void Initialize()
        {
            _borderEnemy = new Border();

            _borderEnemy.BorderBrush = Brushes.Black;
            _borderEnemy.BorderThickness = new Thickness(1);
            _borderEnemy.Margin = new Thickness(new Random().Next(0, 1200), new Random().Next(0, 400), 0, 0);
            _borderEnemy.Background = Brushes.Pink;
            _borderEnemy.Height = 50;
            _borderEnemy.Width = 50;

            _parentPanel.Children.Add(_borderEnemy);
        }

        public void DestroyEnemy(ModelEnemy enemy)
        {
            _parentPanel.Children.Remove(_borderEnemy);
        }
    }
}
