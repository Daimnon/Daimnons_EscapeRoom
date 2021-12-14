using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneState : StateMachine
{
    public StateA StateAInstance;
    public StateB StateBInstance;
    public StateC StateCInstance;
    public StateD StateDInstance;

    public Rigidbody PlayerRb;
    public float Speed = 0f;
    private void Awake()
    {
        StateAInstance = new StateA(this);
        StateBInstance = new StateB(this);
        StateCInstance = new StateC(this);
        StateDInstance = new StateD(this);
    }

    protected override BaseState GetInitialState()
    {
        return StateAInstance;
    }
}
