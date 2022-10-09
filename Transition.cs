using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for creating and serializing a Transition
[System.Serializable]
public class Transition
{
    public Decision decision;
    public State trueState;
    public State falseState;
}
