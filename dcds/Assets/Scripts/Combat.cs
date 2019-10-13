using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An instance of combat between combatants
/// </summary>
public class Combat : MonoBehaviour {

#region FIELDS
    //  FIELDS
    private List<Combatant> combatants = new List<Combatant>();

    private Vector3 combatCenter;
    public Vector3 CombatCenter { get { return combatCenter; } }
    #endregion

#region START/UPDATE
    // Start is called before the first frame update
    void Start() {
        //  TODO: After grid is complete, snap allies and enemies to tiles
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
        c.EnterCombat();
        combatants.Add(c);
    }

    /// <summary>
    /// Change the combat center of the battle, normally centered on the enemy
    /// </summary>
    /// <param name="center"></param>
    public void SetCombatCenter(Vector3 center) {
        combatCenter = center;
    }
#endregion
}
