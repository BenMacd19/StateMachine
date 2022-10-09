using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for creating a descision to be used inside a transition
public abstract class Decision : ScriptableObject
{
    public abstract bool Decide(StateController ctrl);
}