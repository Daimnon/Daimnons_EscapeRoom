using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateB : BaseState
{
    private SceneState _sS;
    private float _horizontalInput;
    private float _verticalInput;

    public StateB(SceneState sM) : base("StateB", sM)
    {
        _sS = (SceneState)StateMachine;
    }
    public override void Enter()
    {
        base.Enter();

        _horizontalInput = 0f;
        _verticalInput = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon)
            StateMachine.ChangeState(_sS.StateBInstance);

        if (Mathf.Abs(_verticalInput) > Mathf.Epsilon)
            StateMachine.ChangeState(_sS.StateBInstance);
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        Vector3 velocity = _sS.PlayerRb.velocity;
        velocity.x = _horizontalInput * _sS.Speed;
        velocity.z = _verticalInput * _sS.Speed;

        _sS.PlayerRb.velocity = velocity;
    }
}
