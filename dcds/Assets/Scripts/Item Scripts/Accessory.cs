using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Contributors: Tori
namespace Assets.Scripts
{
    public abstract class Accessory : Item
    {
        public abstract bool Equip();
        public abstract bool Unequip();
    }

}
