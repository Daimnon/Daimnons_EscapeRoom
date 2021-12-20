using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotographyRoomState : BaseState
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

    //constructor that impliments "StateC" and sM parameters to base constructor
    public PhotographyRoomState(SceneState sM) : base("PhotographyRoomState", sM) { }

    //when starting state
    public override void Enter()
    {
        base.Enter();

        (CurrentStateMachine as SceneState).PlayerTr.position = new Vector3(-30.5f, 3.5f, -22.5f);
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

        Hacks();
    }

    public void Hacks()
    {
        //lobby state quickhack
        if (Input.GetKey(KeyCode.Alpha1))
            CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).LobbyStateInstance);
        //photo & toilet intersection state quickhack
        if (Input.GetKey(KeyCode.Alpha2))
            CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).PhotoToiletIntersectionInstance);
        //photography room state quickhack
        if (Input.GetKey(KeyCode.Alpha3))
            CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).PhotographyRoomStateInstance);
        //toilets room state quickhack
        if (Input.GetKey(KeyCode.Alpha4))
            CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).ToiletsRoomStateInstance);
    }

    public void GoLeft()
    {
        Debug.Log("Executed Photography Room Go Left");
        CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).PhotoToiletIntersectionInstance);
    }

    public void GoRight()
    {
        Debug.Log("Executed Photography Room Go Right");
        CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).PhotoToiletIntersectionInstance);
    }
}
