using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    public class ModelPlyer : ModelBase, IStatusPerson 
    {
        public delegate void PlayerStatus(int value);

        public const byte MAXXP = 20;
        public const byte MINXP = 0;

        protected byte _health = MAXXP;

        protected ViewBase _view;

        public static event PlayerStatus PlayerStatusSab;

        public static event Action DeatPlayer;
        
        public byte Health
        {
            get => _health;
            protected set
            {
                _health = value;
                OnPropertyChanged(nameof(Health));
            }
        }

        public void Damage(byte value)
        {
            if (Health - value <= MINXP)
            {
                Health = MINXP;
                PlayerStatusSab?.Invoke(Health);
                DeatPlayer.Invoke();
            }
            else
                Health -= value;
            PlayerStatusSab?.Invoke(Health);
        }

        public void Recovery(byte value)
        {
            if (Health + value > MAXXP)
                Health = MAXXP;
            else
                Health += value;
            PlayerStatusSab?.Invoke(Health);
        }
    }
}
