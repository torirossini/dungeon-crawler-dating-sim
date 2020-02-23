using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

namespace Assets.Scripts
{
    [CommandInfo("Custom", "SaveVariables", "Saves modified variables back into NPC script")]
    [AddComponentMenu("")]
    public class SaveVariables : Command
    {
        [SerializeField] protected NPC thisNPC;

        [Tooltip("Current Mood enum (Good 0, Neutral 1, Bad 2)")]
        [VariableProperty(typeof(IntegerVariable))]
        [SerializeField] protected IntegerVariable mood;

        [Tooltip("Stance scale from -20 to 20")]
        [VariableProperty(typeof(IntegerVariable))]
        [SerializeField] protected IntegerVariable stance;

        public override void OnEnter()
        {
            thisNPC = gameObject.GetComponentInParent<NPC>();

            if (mood != null)
            {
                thisNPC.currentMood = (NPC.Mood)mood.Value;
            }

            if (stance != null)
            {
                thisNPC.stance = stance.Value;
            }

            Continue();
        }
    }
}
