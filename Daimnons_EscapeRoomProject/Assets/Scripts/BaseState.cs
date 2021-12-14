using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{
    public string Name;
    protected StateMachine StateMachine;
    public BaseState(string name, StateMachine sM)
    {
        Name = name;
        StateMachine = sM;
    }
    public virtual void Enter() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
    public virtual void Exit() { }
}
