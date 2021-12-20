using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoToiletIntersection : BaseState
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

    //constructor that impliments "StateB" and sM parameters to base constructor
    public PhotoToiletIntersection(SceneState sM) : base("Photo Toilet Intersection", sM) { }

    //when starting state
    public override void Enter()
    {
        base.Enter();

        (CurrentStateMachine as SceneState).PlayerTr.position = new Vector3(-5.5f, 3.5f, -5f);
        (CurrentStateMachine as SceneState).PlayerTr.rotation = Quaternion.Euler(0f, -90f, 0f);
        (CurrentStateMachine as SceneState).PlayerTr.localScale = new Vector3(1.5f, 2, 1.5f);

        _horizontalInput = 0f;
        _verticalInput = 0f;
    }

    //when updating state
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        //lobby state
        if (Input.GetKey(KeyCode.Alpha1))
            CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).LobbyStateInstance);
        //photo & toilet intersection state
        if (Input.GetKey(KeyCode.Alpha2))
            CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).PhotoToiletIntersectionInstance);
        //photography room state
        if (Input.GetKey(KeyCode.Alpha3))
            CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).PhotographyRoomStateInstance);
        //toilets room state
        if (Input.GetKey(KeyCode.Alpha4))
            CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).ToiletsRoomStateInstance);

        /*if (Mathf.Abs(_verticalInput) > Mathf.Epsilon)
            StateMachine.ChangeState(((SceneState)StateMachine).StateBInstance);*/
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        //Vector3 velocity = _sS.PlayerRb.velocity;
        //velocity.x = _horizontalInput * _sS.Speed;
        //velocity.z = _verticalInput * _sS.Speed;
        //
        //_sS.PlayerRb.velocity = velocity;
    }

    public void GoLeft()
    {
        Debug.Log("Executed State B Go Left");
        CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).PhotographyRoomStateInstance);
    }

    public void GoRight()
    {
        Debug.Log("Executed State B Go Right");
        CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).ToiletsRoomStateInstance);
    }

    public BaseState ReturnCurrentState()
    {
        if ((CurrentStateMachine as SceneState).IsCurrentState)
        {
            return this;
        }

        return CurrentBaseState<BaseState>();
    }
}
