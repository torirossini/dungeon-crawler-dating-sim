using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

namespace Assets.Scripts
{
    [CommandInfo("Custom", "LoadVariables", "Loads external variables")]
    [AddComponentMenu("")]
    public class LoadVariables : Command
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
                mood.Value = (int)thisNPC.currentMood;
            }

            if (stance != null)
            {
                stance.Value = thisNPC.stance;
            }

            if (mood.Value == 0)
            {
                stance.Value += 10;
            }
            else if (mood.Value == 2)
            {
                stance.Value -= 10;
            }
            
            //lover
            if(stance.Value <= -17)
            {
                
            }
            //like
            else if (-17 < stance.Value && stance.Value < -5)
            {

            }
            //neutral
            else if (-5 <= stance.Value && stance.Value <= 5)
            {

            }
            //dislike
            else if (5 < stance.Value && stance.Value < 17)
            {

            }
            //hate
            else if (17 <= stance.Value)
            {

            }

            Continue();
        }
    }
}
