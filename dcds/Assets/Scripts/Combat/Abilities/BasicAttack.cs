using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Regular base attack. Does not change.
/// </summary>
public class BasicAttack {
    public int attackModifier;

    public BasicAttack() {}

    /// <summary>
    /// User attacks enemy for their current attack amount (Plus a modifier if needed)
    /// </summary>
    /// <param name="user"></param>
    /// <param name="userTempAttack"></param>
    /// <param name="enemy"></param>
    public void Use(Combatant user, int userTempAttack, Combatant enemy) {
        enemy.TakeDamage(user.Attack + userTempAttack + attackModifier);
    }

    public string Name() { return "Basic Attack"; }
}
