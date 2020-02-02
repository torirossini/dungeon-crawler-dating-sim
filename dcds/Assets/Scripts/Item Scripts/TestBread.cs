using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// test child of a consumable item
    /// </summary>
    public class TestBread : Consumable
    {
        // placeholder implementation
        public override bool Consume(int number = 1)
        {
            return false;
        }
    }

}
