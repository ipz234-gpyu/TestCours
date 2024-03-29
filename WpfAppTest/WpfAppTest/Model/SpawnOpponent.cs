﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using WpfAppTest.Model;

namespace WpfAppTest
{
    public class SpawnOpponent : ModelAbstract
    {
        public ModelEnemy[] Enemys;
        public MainWindow main;
        private DispatcherTimer _timer;
        private Random _random;
        public int PointGame = 0;

        public SpawnOpponent(MainWindow main, int count)
        {
            this.main = main;
            Enemys = new ModelEnemy[count];

            for (int i = 0; i < Enemys.Length; i++)
            {
                int enemyIndex = i;
                Enemys[i] = new ModelEnemy(main.SpawnOpponent);
                Enemys[i]._Enemy._borderEnemy.MouseLeftButtonDown += (sender, e) => BattonDamage_Click(sender, e, Enemys[enemyIndex]);
                Enemys[i].DeatPlayer += Person_OnDeaid;
            }
            _random = new Random();
            StartRandomizingPosition();
        }

        private void BattonDamage_Click(object sender, RoutedEventArgs e, ModelEnemy enemy)
        {
            enemy?.Damage(20);
        }

        public void Person_OnDeaid(ModelEnemy enemy)
        {
            enemy = null;
            PointGame++;
            main.Point.Text = $"{PointGame}";
        }

        private void StartRandomizingPosition()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Enemys.Length; i++)
            {
                double newX = _random.Next(-(int)Enemys[i]._Enemy._parentPanel.ActualWidth, (int)Enemys[i]._Enemy._parentPanel.ActualWidth);
                double newY = _random.Next(-(int)Enemys[i]._Enemy._parentPanel.ActualHeight, (int)Enemys[i]._Enemy._parentPanel.ActualHeight-40);
                
                Enemys[i]._Enemy._borderEnemy.Margin = new Thickness(newX, newY, 0, 0);
            }
        }
    }
}
