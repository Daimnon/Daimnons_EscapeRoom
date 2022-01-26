using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// fix buttons func in relation to rotation
public class ServersRoomState : BaseState
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
    public ServersRoomState(SceneState sM) : base("ServersRoomState", sM) { }

    //when starting state
    public override void Enter()
    {
        base.Enter();

        (CurrentStateMachine as SceneState).PlayerTr.position = new Vector3(-26.5f, 3.5f, 2f);
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
        //toilet-servers intersection state quickhack
        if (Input.GetKey(KeyCode.Alpha2))
            CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).ToiletServerIntersectionInstance);
        //toilets room state quickhack
        if (Input.GetKey(KeyCode.Alpha3))
            CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).ToiletsRoomInstance);
        //servers room state quickhack
        if (Input.GetKey(KeyCode.Alpha4))
            CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).ServersRoomVentStateInstance);
        //theater room state quickhack
        if (Input.GetKey(KeyCode.Alpha5))
            CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).TheaterRoomStateInstance);
        //library room state quickhack
        if (Input.GetKey(KeyCode.Alpha6))
            CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).LibraryRoomStateInstance);
    }

    public void GoForward()
    {
        Debug.Log("Executed Toilets Room Go Right");
        CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).ServersRoomVentStateInstance);
    }

    public void GoBackwards()
    {
        Debug.Log("Executed Toilets Room Go Right");
        CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).ToiletServerIntersectionInstance);
    }
}
