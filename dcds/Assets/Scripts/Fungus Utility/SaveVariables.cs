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

            //reset stance from mood
            if (mood.Value == 0)
            {
                stance.Value -= 10;
            }
            else if (mood.Value == 2)
            {
                stance.Value += 10;
            }

            //set min and max limits to stance
            if (stance.Value > 20)
            {
                stance.Value = 20;
            }
            else if(stance.Value < -20)
            {
                stance.Value = -20;
            }



            //save mood and stance values back into NPC class
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
