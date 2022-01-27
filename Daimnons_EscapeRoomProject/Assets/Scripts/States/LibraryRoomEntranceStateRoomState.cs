using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryRoomEntranceState : BaseState
{
    //constructor that impliments "StatA" and sM parameters to base constructor
    public LibraryRoomEntranceState(SceneState sM) : base("LibraryRoomEntranceState", sM) { }

    //when starting state
    public override void Enter()
    {
        base.Enter();

        (CurrentStateMachine as SceneState).IsCurrentState = true;

        (CurrentStateMachine as SceneState).PlayerTr.position = new Vector3(-16f, 3.5f, 11.5f);
        (CurrentStateMachine as SceneState).PlayerTr.rotation = Quaternion.Euler(0f, 0f, 0f);
        (CurrentStateMachine as SceneState).PlayerTr.localScale = new Vector3(1.5f, 2, 1.5f);
    }

    //when updating state
    public override void UpdateLogic()
    {
        base.UpdateLogic();

        Hacks();
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
        //library room entrance state quickhack
        if (Input.GetKey(KeyCode.Alpha6))
            CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).LibraryRoomEntranceStateInstance);
        //library room state quickhack
        if (Input.GetKey(KeyCode.Alpha6))
            CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).LibraryRoomStateInstance);
    }

    public void GoLeft()
    {
        Debug.Log("Executed Library Room Entrance State Go Left");
        CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).ToiletServerIntersectionInstance);
    }

    public void GoRight()
    {
        Debug.Log("Executed Library Room Entrance State Go Left");
        CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).TheaterDoorStateInstace);
    }

    public void GoForward()
    {
        Debug.Log("Executed Library Room Entrance State Go Forward");
        CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).LibraryRoomStateInstance);
    }

    public void GoBackwards()
    {
        Debug.Log("Executed Library Room Entrance State Go Backwards");
        CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).LobbyStateInstance);
    }
}
