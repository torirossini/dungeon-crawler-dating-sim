using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An instance of combat between combatants
/// </summary>
public class Combat : MonoBehaviour { 

    //  TODO: Turn order, timed delays between turns

#region FIELDS
    //  FIELDS
    private readonly List<Combatant> combatants = new List<Combatant>();
    private readonly Queue<Combatant> turnOrder = new Queue<Combatant>();
    private readonly Queue<Combatant> futureTurns = new Queue<Combatant>();

    private Combatant centerEnemy = null;
    private Vector3 combatCenter;
    public Vector3 CombatCenter { get { return combatCenter; } }
    #endregion

#region START/UPDATE
    // Start is called before the first frame update
    void Start() {
        DetermineTurnOrder();
    }

    // Update is called once per frame
    void Update() {
        
    }
    #endregion

#region METHODS
    /// <summary>
    /// Adds a given combatant to the combat
    /// </summary>
    /// <param name="c">Combatant to enter the combat</param>
    public void AddParticipant(Combatant c) {
        c.EnterCombat(this);
        combatants.Add(c);

        //  Grab that center enemy
        if(centerEnemy == null && !c.IsAlly()) {
            centerEnemy = c;
            combatCenter = centerEnemy.transform.position;
        }
    }

    /// <summary>
    /// Determines turn order for the combat
    /// </summary>
    private void DetermineTurnOrder() {
        turnOrder.Clear();
        List<Combatant> sorted = combatants.OrderByDescending(c => c.Speed).ToList();
        foreach (Combatant c in sorted) {
            turnOrder.Enqueue(c);
            if (futureTurns.Count == 0)
                futureTurns.Enqueue(c);
        }
    }
#endregion
}
