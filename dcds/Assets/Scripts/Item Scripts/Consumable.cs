using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Contributors: Tori
namespace Assets.Scripts
{
    /// <summary>
    /// Consumable items will inherit this class
    /// </summary>
    public abstract class Consumable:Item
    {
        int numberInStack;
        abstract bool Consume(int number = 1);
    }
    
}
