using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for controlling the flow of the finite state machine
public abstract class StateController : MonoBehaviour
{
    [Header("State Settings")]
    public State startState; 
    public State remainState;

    [HideInInspector] public State currentState;

    // Assign the starting state to the current state
    // Enter the current state
    public virtual void Start()
    {
        currentState = startState;
        currentState.EnterState(this);
    }

    // Every frame the state ticks
    public virtual void Update()
    {
        currentState.UpdateState(this);
    }

    // Transitions to the next state if the inputted state is not equal to the current state
    // Exits the current state, then enter the next state
    public virtual void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState.ExitState(this);
            currentState = nextState;
            currentState.EnterState(this);
        }
    }

    public void OnDrawGizmos() 
    {
        if (currentState != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(this.transform.position, 2f);
        }
    }
}
