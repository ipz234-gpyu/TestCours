using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfAppTest.Model;

namespace WpfAppTest
{
    public class ModelEnemy : ModelAbstract
    {
        public const byte MAXXP = 20;
        public const byte MINXP = 0;

        protected byte _health = MAXXP;
        public ViewEnemy _Enemy;

        public delegate void PlayerStatus(int value);
        public static event PlayerStatus PlayerStatusSab;

        public event Action<ModelEnemy> DeatPlayer;

        public byte Health
        {
            get => _health;
            protected set
            {
                _health = value;
            }
        }

        public ModelEnemy(Grid _Panel)
        {
            _Enemy = new ViewEnemy(_Panel);
            DeatPlayer += _Enemy.DestroyEnemy;
        }

        public void Damage(byte value)
        {
            if (Health - value <= MINXP)
            {
                Health = MINXP;
                PlayerStatusSab?.Invoke(Health);
                DeatPlayer.Invoke(this);
            }
            else
                Health -= value;
            PlayerStatusSab?.Invoke(Health);
        }
    }
}
