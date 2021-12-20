using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateD : BaseState
{
    //get references
    #region Serialized Fields
    [SerializeField]
    private Camera _mainCam;

    [SerializeField]
    private Transform _mainCamTr;

    [SerializeField]
    private Collider _playerCol;
    #endregion

    //movement inputs
    private float _horizontalInput;
    private float _verticalInput;

    //constructor that impliments "StateD" and sM parameters to base constructor
    public StateD(SceneState sM) : base("StateD", sM) { }

    //when starting state
    public override void Enter()
    {
        base.Enter();

        _horizontalInput = 0f;
        _verticalInput = 0f;
    }

    //when updating state
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

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
        Debug.Log("Executed State D Go Left");
        CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).StateAInstance);
    }

    public void GoRight()
    {
        Debug.Log("Executed State D Go Right");
        CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).StateAInstance);
    }
}
