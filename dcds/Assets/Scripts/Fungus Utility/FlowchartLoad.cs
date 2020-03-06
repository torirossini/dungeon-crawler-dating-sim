using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FlowchartLoad : MonoBehaviour
{
    [SerializeField] public Flowchart flowchart;
    [SerializeField] public Animator textBoxAnim;

    [SerializeField] public RuntimeAnimatorController neutral;
    [SerializeField] public AnimatorOverrideController like;
    [SerializeField] public AnimatorOverrideController love;
    [SerializeField] public AnimatorOverrideController dislike;
    [SerializeField] public AnimatorOverrideController hate;

    private int stance;

    private void Awake()
    {
        flowchart = gameObject.GetComponent<Flowchart>();
    }

    // Update is called once per frame
    void Update()
    {
        stance = flowchart.GetIntegerVariable("Stance");
        if (flowchart.isActiveAndEnabled)
        {
            if(stance < -15)
            {
                textBoxAnim.runtimeAnimatorController = hate;
            }
            else if(-15 <= stance && stance < -5)
            {
                textBoxAnim.runtimeAnimatorController = dislike;
            }
            else if(-5 <= stance && stance <= 5)
            {
                textBoxAnim.runtimeAnimatorController = neutral;
            }
            else if(5 < stance && stance <= 15)
            {
                textBoxAnim.runtimeAnimatorController = like;
            }
            else if(stance < 15)
            {
                textBoxAnim.runtimeAnimatorController = love;
            }
        }
        else
        {
            textBoxAnim.runtimeAnimatorController = null;
        }
    }
}
