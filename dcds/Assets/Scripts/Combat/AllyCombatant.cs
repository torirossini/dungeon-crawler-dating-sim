using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyCombatant : Combatant {

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public override void TakeTurn(Combat c) {
        throw new System.NotImplementedException();
    }

    public override bool IsAlly() { return true; }
}
