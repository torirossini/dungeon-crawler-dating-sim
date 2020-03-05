using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

namespace Assets.Scripts
{
    [CommandInfo("Custom", "InteractionTrigger", "Modifies Stance and/or Mood by specified number.")]
    [AddComponentMenu("")]
    public class InteractionTrigger : Command
    {
        [Tooltip("Current Mood enum (Good 0, Neutral 1, Bad 2)")]
        [VariableProperty(typeof(IntegerVariable))]
        [SerializeField] protected IntegerVariable mood;

        [Tooltip("Stance scale from -20 to 20")]
        [VariableProperty(typeof(IntegerVariable))]
        [SerializeField] protected IntegerVariable stance;

        [Tooltip("Amount of stance change from this interaction")]
        [SerializeField] protected int stanceChangeValue;

        [SerializeField] protected bool changeMood = false;

        [Tooltip("Mood to change to: Good(0) Neutral(1) Bad(2)")]
        [SerializeField] protected int newMood;

        public override void OnEnter()
        {
            if(mood != null && changeMood)
            {
                mood.Value = newMood;
            }

            if(stance != null)
            {
                stance.Value += stanceChangeValue;
            }

            Continue();
        }
    }
}