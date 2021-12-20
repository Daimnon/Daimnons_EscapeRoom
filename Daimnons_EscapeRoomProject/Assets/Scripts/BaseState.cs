using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{
    public string Name;
    public string CurrentStateName;
    protected StateMachine CurrentStateMachine;
    public BaseState(string name, StateMachine sM)
    {
        Name = name;
        CurrentStateMachine = sM;
    }
    public virtual void Enter() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
    public virtual void Exit() { }

    public StateMachine CurrentState<T>() where T : StateMachine
    {
        return CurrentStateMachine;
    }
}
