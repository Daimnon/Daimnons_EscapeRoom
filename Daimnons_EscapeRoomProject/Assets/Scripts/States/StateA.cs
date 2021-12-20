using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateA : BaseState
{
    //movement inputs
    private float _horizontalInput;
    private float _verticalInput;

    //constructor that impliments "StatA" and sM parameters to base constructor
    public StateA(SceneState sM) : base("StateA", sM) { }

    //when starting state
    public override void Enter()
    {
        base.Enter();

        (CurrentStateMachine as SceneState).PlayerTr.position = new Vector3(0, 3.5f, -33.25f);
        (CurrentStateMachine as SceneState).PlayerTr.rotation = Quaternion.Euler(0, 0, 0);
        (CurrentStateMachine as SceneState).PlayerTr.localScale = new Vector3(1.5f, 2, 1.5f);
    }

    //when updating state
    public override void UpdateLogic()
    {
        base.UpdateLogic();

        //left
        if (_horizontalInput < 0)
            CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).StateBInstance);
        //forward
        if (_verticalInput > 0)
            CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).StateCInstance);
        //right
        if (_horizontalInput > 0)
            CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).StateDInstance);
        //backwards
        if (_verticalInput > 0)
            CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).StateAInstance);

        /*if (Mathf.Abs(_verticalInput) > Mathf.Epsilon)
            StateMachine.ChangeState(((SceneState)StateMachine).StateBInstance);*/
    }

    public void GoLeft()
    {
        Debug.Log("Executed State A Go Left");
        CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).StateBInstance);
    }

    public void GoRight()
    {
        Debug.Log("Executed State A Go Right");
        //CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).StateBInstance);
    }
}
