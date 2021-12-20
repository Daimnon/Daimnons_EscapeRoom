using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyState : BaseState
{
    //movement inputs
    private float _mouseX;
    private float _mouseY;

    //constructor that impliments "StatA" and sM parameters to base constructor
    public LobbyState(SceneState sM) : base("Lobby", sM) { }

    //when starting state
    public override void Enter()
    {
        base.Enter();
        (CurrentStateMachine as SceneState).IsCurrentState = true;
        (CurrentStateMachine as SceneState).PlayerTr.position = new Vector3(0f, 3.5f, -5f);
        (CurrentStateMachine as SceneState).PlayerTr.rotation = Quaternion.Euler(0f, 0f, 0f);
        (CurrentStateMachine as SceneState).PlayerTr.localScale = new Vector3(1.5f, 2, 1.5f);
    }

    //when updating state
    public override void UpdateLogic()
    {
        base.UpdateLogic();

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

    public override void Exit()
    {
        base.Exit();

        (CurrentStateMachine as SceneState).IsCurrentState = false;
    }

    public void GoLeft()
    {
        Debug.Log("Executed State A Go Left");
        CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).PhotoToiletIntersectionInstance);
    }

    public void GoRight()
    {
        Debug.Log("Executed State A Go Right");
        //CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).StateBInstance);
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
