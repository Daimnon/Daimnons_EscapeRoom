using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheaterDoorState : BaseState
{

    //constructor that impliments "StatA" and sM parameters to base constructor
    public TheaterDoorState(SceneState sM) : base("TheaterDoorState", sM) { }

    //when starting state
    public override void Enter()
    {
        base.Enter();

        (CurrentStateMachine as SceneState).IsCurrentState = true;

        (CurrentStateMachine as SceneState).PlayerTr.position = new Vector3(11.75f, 3.5f, -10f);
        (CurrentStateMachine as SceneState).PlayerTr.rotation = Quaternion.Euler(0f, 90f, 0f);
        (CurrentStateMachine as SceneState).PlayerTr.localScale = new Vector3(1.5f, 2, 1.5f);
    }

    //when updating state
    public override void UpdateLogic()
    {
        base.UpdateLogic();

        Hacks();

        /* for movement
         * if (Mathf.Abs(_verticalInput) > Mathf.Epsilon)
            StateMachine.ChangeState(((SceneState)StateMachine).StateBInstance);*/
    }

    public override void Exit()
    {
        base.Exit();

        (CurrentStateMachine as SceneState).IsCurrentState = false;
    }

    public void Hacks()
    {
        //lobby state quickhack
        if (Input.GetKey(KeyCode.Alpha1))
            CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).LobbyStateInstance);
        //photo & toilet intersection state quickhack
        if (Input.GetKey(KeyCode.Alpha2))
            CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).ToiletServerIntersectionInstance);
        //photography room state quickhack
        if (Input.GetKey(KeyCode.Alpha3))
            CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).ToiletsRoomInstance);
        //toilets room state quickhack
        if (Input.GetKey(KeyCode.Alpha4))
            CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).ServersRoomStateInstance);
        //theater room state quickhack
        if (Input.GetKey(KeyCode.Alpha5))
            CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).TheaterStateInstance);
    }

    public void GoForward()
    {
        Debug.Log("Executed Lobby Go Left");
        CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).TheaterStateInstance);
    }

    public void GoBackwards()
    {
        Debug.Log("Executed Lobby Go Left");
        CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).LobbyStateInstance);
    }
}
