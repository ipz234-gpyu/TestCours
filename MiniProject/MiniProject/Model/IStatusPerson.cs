﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    public interface IStatusPerson
    {
        void Damage(byte value);
        void Recovery(byte value);
    }
}
