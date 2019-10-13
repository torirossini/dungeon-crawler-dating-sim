using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Combatant : MonoBehaviour {

    private enum basicAttacks {
        defaultBasicAttack,
        nondefaultBasicAttack
    };

    #region FIELDS
    //  FIELDS

    private CombatantManager ManagerScript;

    [SerializeField]
    private basicAttacks basic = basicAttacks.defaultBasicAttack;

    private bool isInCombat = false;
    public bool IsInCombat { get { return isInCombat; } }
    private Combat currentCombat = null;
    public Combat CurrentCombat { get { return currentCombat; } }
#endregion

#region STATS&ATTACKS
    [SerializeField]
    private int attack = 10, defense = 10, maxHp = 10, maxMana = 10, speed = 1, luck = 1;
    private int tempAttack = 0, tempDefense = 0, tempSpeed = 0, tempLuck = 1;
    private int currentHp, currentMana;
    
    [SerializeField]
    private BasicAttack basicAttack;
    [SerializeField]
    private BaseAbility specialAttack;
    [SerializeField]
    private BaseAbility supportAbility;
    [SerializeField]
    private BaseAbility defenseAbility;

    public int Attack { get { return attack; } set { attack = value; if (attack < 0) attack = 0; } } 
    public int Defense { get { return defense; } set { defense = value; if (defense < 0) defense = 0; } }
    public int Speed { get { return speed; } set { speed = value; if (speed < 0) speed = 0; } }
    public int Luck { get { return luck; } set { luck = value; if (luck < 0) luck = 0; } }
    public int MaxHp { get { return maxHp; } set { maxHp = value; if (maxHp < 1) maxHp = 1; } }
    public int MaxMana { get { return maxMana; } set { maxMana = value; if (maxMana < 0) maxMana = 0; } }
    #endregion

#region START/UPDATE

    // Start is called before the first frame update
    void Start() {
        currentHp = maxHp;
        currentMana = maxMana;
        ManagerScript = GameObject.Find("CombatantManager").GetComponent<CombatantManager>();
    }

    // Update is called once per frame
    void Update() {
        
    }

#endregion

#region METHODS

    /// <summary>
    /// Combatant takes an amount of damage reduced by armor
    /// </summary>
    /// <param name="amount">Unmodified damage amount to be taken</param>
    public void TakeDamage(int amount) {
        //  Lose hp equal to the amount - defense, maybe more bonuses later
        currentHp -= (amount > defense ? amount - defense : 0);

        //  Maybe implement undying effect or emergency heal
        if (currentHp <= 0)
            Die();
    }

    /// <summary>
    /// Combatant's HitPoints have reached zero, and is to die.
    /// </summary>
    protected void Die() {
        //  TODO: DIE
    }

    /// <summary>
    /// Sets isInCombat to true, calls SnapToGrid
    /// </summary>
    public void EnterCombat(Combat c) {
        isInCombat = true;
        currentCombat = c;
        SnapToGrid();
    }

    /// <summary>
    /// Sets isInCombat to false, may be used for other things later
    /// </summary>
    public void ExitCombat() {
        isInCombat = false;
        currentCombat = null;
    }

    /// <summary>
    /// Snaps to the nearest whole number of unity units
    /// </summary>
    public void SnapToGrid() {
        Vector3 position = transform.position;
        transform.position = new Vector3(
            Mathf.Round(position.x),
            Mathf.Round(position.y),
            position.z);
    }

    /// <summary>
    /// Any child of Combatant is either an ally or enemy
    /// </summary>
    /// <returns>Returns whether the combatant is an ally of the player</returns>
    public abstract bool IsAlly();

    /// <summary>
    /// Take this combatant's turn in a combat.
    /// </summary>
    public abstract void TakeTurn(Combat c);
    
    #endregion

}
