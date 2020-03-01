using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

namespace Assets.Scripts
{
    [CommandInfo("Custom", "CheckMood", "Adjusts Stance variable based on Mood at the start of dialogue")]
    [AddComponentMenu("")]
    public class CheckMood : Command
    {
        [Tooltip("Current Mood enum (Good 0, Neutral 1, Bad 2)")]
        [VariableProperty(typeof(IntegerVariable))]
        [SerializeField] protected IntegerVariable mood;

        [Tooltip("Stance scale from -20 to 20")]
        [VariableProperty(typeof(IntegerVariable))]
        [SerializeField] protected IntegerVariable stance;

        public override void OnEnter()
        {
            if(mood.Value == 0)
            {
                stance.Value += 10;
            }
            else if(mood.Value == 2)
            {
                stance.Value -= 10;
            }

            Continue();
        }
    }
}
