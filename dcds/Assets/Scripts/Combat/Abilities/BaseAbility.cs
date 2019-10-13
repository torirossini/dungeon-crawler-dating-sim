using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAbility {
    private int manaCost;
    public int ManaCost { get { return manaCost; } }

    public abstract string Name();
}
