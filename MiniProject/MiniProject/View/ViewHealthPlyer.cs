﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MiniProject
{
    public class ViewHealthPlyer : ViewBase
    {
        public ProgressBar _progressBarHealth;
        protected Grid _parentPanel;

        public ViewHealthPlyer(Grid parentPanel) : base()
        {
            _parentPanel = parentPanel;
            Initialize();
        }

        public void viewHealth(int value) =>
            _progressBarHealth.Value = value;

        protected override void Initialize()
        {
            _progressBarHealth = new ProgressBar();

            _progressBarHealth.Name = "Health";
            _progressBarHealth.Maximum = 20;
            _progressBarHealth.Value = _progressBarHealth.Maximum;
            _progressBarHealth.Height = 40;
            _progressBarHealth.Width = 200;
            _progressBarHealth.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            _progressBarHealth.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            _progressBarHealth.Margin = new System.Windows.Thickness(10, 10, 0, 0);
            _progressBarHealth.Foreground = System.Windows.Media.Brushes.Red;
            _progressBarHealth.Background = null;
            _progressBarHealth.BorderBrush = System.Windows.Media.Brushes.Black;

            _parentPanel.Children.Add(_progressBarHealth);
        }
    }
}
