using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for specifying the behavior to be executed in a state
public abstract class StateBehavior : ScriptableObject
{
    public abstract void Enter(StateController ctrl);

    public abstract void Tick(StateController ctrl);

    public abstract void Exit(StateController ctrl);
}
