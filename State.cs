using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for creating a State for the StateController class
[CreateAssetMenu (menuName = "PluggableAI/State")]
public class State : ScriptableObject
{  
    // The behavior that the state should execute
    public StateBehavior stateBehavior;
    // Transitions to check from this state
    public Transition[] transitions;
    
    public Color sceneGizmoColor = Color.gray;

    public void EnterState(StateController ctrl)
    {
        stateBehavior.Enter(ctrl);
    }

    // Every frame the behavior ticks and then each transition is checked
    public void UpdateState(StateController ctrl)
    {
        stateBehavior.Tick(ctrl);
        CheckTransitions(ctrl);
    }

    public void ExitState(StateController ctrl)
    {
        stateBehavior.Exit(ctrl);
    }

    // Check all transitions and evaluate which state to next move to
    private void CheckTransitions(StateController ctrl)
    {
        // Loop through all transitions
        for (int i = 0; i < transitions.Length; i++)
        {
            // Stores current decision bool
            bool decisionSucceeded = transitions[i].decision.Decide(ctrl);

            // If the decision returns true then the next state is the true state
            if (decisionSucceeded)
            {
                ctrl.TransitionToState(transitions[i].trueState);
            }
            // If the decision returns false then the next state is the false state
            else
            {
                ctrl.TransitionToState(transitions[i].falseState);
            }
        }
    }
}
