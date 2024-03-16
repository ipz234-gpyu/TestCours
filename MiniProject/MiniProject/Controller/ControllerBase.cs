using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MiniProject
{
    public class ControllerBase
    {
        public IStatusPerson Model;
        public ViewHealthPlyer View;
        public MainWindow main;

        public ControllerBase(MainWindow main) 
        {
            this.main = main;
            Model = new ModelPlyer();
            View = new ViewHealthPlyer(main.MainScrren);

            ModelPlyer.PlayerStatusSab += View.viewHealth; 
            main.KeyDown += Window_KeyDown;
            main.Plyer.MouseLeftButtonDown += BattonDamage_Click;
            main.Plyer.MouseRightButtonDown += BattonRecovery_Click;
            ModelPlyer.DeatPlayer += Person_OnDeaid;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                Thickness newMargin = main.Plyer.Margin;
                newMargin.Top -= 10;
                newMargin.Bottom += 10;
                main.Plyer.Margin = newMargin;
            }
            else if (e.Key == Key.S)
            {
                Thickness newMargin = main.Plyer.Margin;
                newMargin.Top += 10;
                newMargin.Bottom -= 10;
                main.Plyer.Margin = newMargin;
            }
            else if (e.Key == Key.A)
            {
                Thickness newMargin = main.Plyer.Margin;
                newMargin.Left -= 10;
                newMargin.Right += 10;
                main.Plyer.Margin = newMargin;
            }
            else if (e.Key == Key.D)
            {
                Thickness newMargin = main.Plyer.Margin;
                newMargin.Left += 10;
                newMargin.Right -= 10;
                main.Plyer.Margin = newMargin;
            }
        }

        private void BattonDamage_Click(object sender, RoutedEventArgs e) =>
            Model?.Damage(1);

        private void BattonRecovery_Click(object sender, RoutedEventArgs e) =>
            Model?.Recovery(1);

        public void Person_OnDeaid()
        {
            MessageBox.Show($"Персонаж помер!", "Смерть", MessageBoxButton.OK, MessageBoxImage.Information);
            main.Close();
        }
    }
}
