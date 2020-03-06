using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

namespace Assets.Scripts
{
    [CommandInfo("Custom", "AnimateTextBox", "Loads and calls correct triggers for text box animation per each fungus block.")]
    [AddComponentMenu("")]
    public class AnimateTextBox : Command
    {
        [Tooltip("Stance scale from -20 to 20")]
        [VariableProperty(typeof(IntegerVariable))]
        [SerializeField] protected IntegerVariable stance;

        [Tooltip("Animation controller for text box")]
        [VariableProperty(typeof(AnimatorVariable))]
        [SerializeField] protected AnimatorVariable anim;

        [Tooltip("Will there be an interaction animation?")]
        [SerializeField] protected bool doAnim;

        [Tooltip("Is this a positive(true) or negative(false) interaction?")]
        [SerializeField] protected bool triggerType;

        public override void OnEnter()
        {
            //set up correct text box animation loop based on stance
            if (anim != null)
            {
                if (stance.Value < -15)
                {
                    anim.Value.SetTrigger("Hate");
                }
                else if (-15 <= stance.Value && stance.Value < -5)
                {
                    anim.Value.SetTrigger("Dislike");
                }
                else if (-5 <= stance.Value && stance.Value <= 5)
                {
                    anim.Value.SetTrigger("Neutral");
                }
                else if (5 < stance.Value && stance.Value <= 15)
                {
                    anim.Value.SetTrigger("Like");
                }
                else if (stance.Value < 15)
                {
                    anim.Value.SetTrigger("Love");
                }

                if (doAnim)
                {
                    if (triggerType)
                    {
                        anim.Value.SetTrigger("Positive");
                    }
                    else
                    {
                        anim.Value.SetTrigger("Negative");
                    }
                }
            }
            else
            {
                print("Animator inaccessible");
            }

            Continue();
        }
    }
}
