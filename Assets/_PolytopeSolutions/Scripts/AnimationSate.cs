using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSate : MonoBehaviour
{
    private Animator animator;
    public string parameterName;
    private bool currentState;
    public bool startingState;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (startingState)
            SwitchState();
    }
    public void SwitchState() { 
        currentState = !currentState;
        animator.SetBool(parameterName, currentState);
    }
}
