using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfAppTest
{
    public class Controller
    {
        public SpawnOpponent spawnOpponent;
        public ViewHealthPlyer View;
        public MainWindow main;

        public Controller(MainWindow main)
        {
            this.main = main;
            spawnOpponent = new SpawnOpponent(main, 5);
            View = new ViewHealthPlyer(main.MainScrren);
            ModelEnemy.PlayerStatusSab += View.viewHealth;
        }
    }
}
