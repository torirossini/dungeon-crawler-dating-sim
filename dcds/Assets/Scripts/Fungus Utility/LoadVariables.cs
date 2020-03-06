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

        [Tooltip("Has the player spoken to me yet?")]
        [VariableProperty(typeof(BooleanVariable))]
        [SerializeField] protected BooleanVariable spokenTo;

        [Tooltip("Stance scale from -20 to 20")]
        [VariableProperty(typeof(IntegerVariable))]
        [SerializeField] protected IntegerVariable stance;

        [Tooltip("Animator for text box")]
        [VariableProperty(typeof(AnimatorVariable))]
        [SerializeField] protected AnimatorVariable textBoxAnim;

        public override void OnEnter()
        {
            thisNPC = gameObject.GetComponentInParent<NPC>();

            if(spokenTo != null)
            {
                spokenTo.Value = thisNPC.spokenTo;
            }

            if (mood != null)
            {
                mood.Value = (int)thisNPC.currentMood;
            }

            if (stance != null)
            {
                stance.Value = thisNPC.stance;
            }

            if (textBoxAnim != null)
            {
                textBoxAnim.Value.SetInteger("Stance", stance.Value);
            }

            if (mood.Value == 0)
            {
                stance.Value += 10;
            }
            else if (mood.Value == 2)
            {
                stance.Value -= 10;
            }

            Continue();
        }
    }
}
