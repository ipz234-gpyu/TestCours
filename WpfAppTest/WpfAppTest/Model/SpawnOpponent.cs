using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WpfAppTest.Model;

namespace WpfAppTest
{
    public class SpawnOpponent : ModelAbstract
    {
        public ModelEnemy[] Enemys;
        public MainWindow main;
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
                Thread.Sleep(1000);
            }
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

        public void TestEvent (object sender, EventArgs e)
        {

        }
    }
}
