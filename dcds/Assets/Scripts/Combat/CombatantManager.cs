using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CombatantManager : MonoBehaviour {

#region FIELDS
    //  Minimum distance between two enemies for combat to initiate
    [SerializeField]
    private const float MIN_COMBAT_DISTANCE = 1.0f;

    /// <summary>
    /// Allied combatants, both in and out of combat
    /// </summary>
    private List<Combatant> alliedCombatants = new List<Combatant>();
    /// <summary>
    /// Enemy combatants, both in and out of combat
    /// </summary>
    private List<Combatant> enemyCombatants = new List<Combatant>();

    /// <summary>
    /// All active combats in the level
    /// </summary>
    private List<GameObject> activeCombats = new List<GameObject>();
#endregion

#region START/UPDATE
    // Start is called before the first frame update
    void Start() {
        LocateCombatants();
    }

    // Update is called once per frame
    void Update() {
        CheckForCombats();
    }
    #endregion

#region METHODS

    /// <summary>
    /// Loops through alliedCombatants and decides if a combat should start
    /// </summary>
    private void CheckForCombats() {
        foreach(Combatant ally in alliedCombatants) {
            Combatant closestEnemy = null;
            float closestDistance = float.MaxValue;
            //  Continue if ally is already in combat
            if (ally.IsInCombat)
                continue;

            //  Check if in range of active combats
            foreach(GameObject g in activeCombats) {
                Combat c = g.GetComponent<Combat>();
                if(Vector3.Distance(c.CombatCenter,ally.transform.position) <= MIN_COMBAT_DISTANCE)
                    c.AddParticipant(ally);
            }

            //  Check again in case they entered a combat
            if (ally.IsInCombat)
                continue;

            foreach (Combatant enemy in enemyCombatants ) {
                //  Continue if enemy is already in combat
                if (enemy.IsInCombat)
                    continue;

                //  Calculate the closest enemy combatant to the current ally
                float distanceBetween = Vector3.Distance(enemy.transform.position, ally.transform.position);
                if(distanceBetween > closestDistance) {
                    closestEnemy = enemy;
                    closestDistance = distanceBetween;
                }
            }
            //  If the closest enemy is too close
            if(closestDistance <= MIN_COMBAT_DISTANCE) {
                //  Initialize a combat
                Debug.Log("Combat found!");
                AddCombat(ally, closestEnemy);
            }
        }
    }

    /// <summary>
    /// Searches for all gameObjects holding the Combatant 
    /// script and adds them to their respective lists
    /// </summary>
    private void LocateCombatants() {
        //  Grabs every instance of the Combatant script and throws it into an array
        Combatant[] combatants = FindObjectsOfType<Combatant>();

        //  Loops through all combatants and assigns them to their respective lists
        for(int i = 0; i < combatants.Length; i++)
            if (combatants[i].IsAlly())
                alliedCombatants.Add(combatants[i]);
            else
                enemyCombatants.Add(combatants[i]);
    }

    /// <summary>
    /// Initializes an instance of a Combat, including the provided ally and enemy.
    /// </summary>
    /// <param name="ally">Target ally to be participating</param>
    /// <param name="enemy">Target enemy to be participating</param>
    private void AddCombat(Combatant ally, Combatant enemy) {
        GameObject newCombatObject = new GameObject();
        newCombatObject.AddComponent<Combat>();
        Combat newCombat = newCombatObject.GetComponent<Combat>();

        //  Add provided combatants to the combat
        newCombat.AddParticipant(ally);
        newCombat.AddParticipant(enemy);

        //  Combine allied and enemy combatants to reduce repitition
        List<Combatant> allCombatants = new List<Combatant>(alliedCombatants.Count + enemyCombatants.Count);
        allCombatants.AddRange(alliedCombatants);
        allCombatants.AddRange(enemyCombatants);

        //  Add all combatants within range to the combat
        foreach(Combatant c in allCombatants) {
            if (c.IsInCombat)
                continue;
            float distanceBetween = (newCombat.CombatCenter - c.transform.position).sqrMagnitude;
            if (distanceBetween <= MIN_COMBAT_DISTANCE)
                newCombat.AddParticipant(c);
        }

        //  Instantiate a new combat object and script
        

        activeCombats.Add(newCombatObject);
    }

#endregion
}
