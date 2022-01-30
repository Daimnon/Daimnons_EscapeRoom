using UnityEngine;

public class ToiletServerIntersectionState : BaseState
{
    #region Constructor
    //constructor that impliments "StateB" and sM parameters to base constructor
    public ToiletServerIntersectionState(SceneState sM) : base("ToiletServerIntersectionState", sM) { }
    #endregion

    #region Overrides
    //when starting state
    public override void Enter()
    {
        base.Enter();

        (CurrentStateMachine as SceneState).PlayerTr.position = new Vector3(-5.5f, 3.5f, -5f);
        (CurrentStateMachine as SceneState).PlayerTr.rotation = Quaternion.Euler(0f, -90f, 0f);
        (CurrentStateMachine as SceneState).PlayerTr.localScale = new Vector3(1.5f, 2, 1.5f);

        (CurrentStateMachine as SceneState)._mouseLook.rotation = new Vector2(-90f, 0f);
    }

    //when updating state
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        Hacks();
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
    #endregion

    #region QuickHacks
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
    #endregion

    #region Unity Events
    public void GoLeft()
    {
        Debug.Log("Executed Server-Toilet Intersection Go Left");
        CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).ToiletsRoomInstance);
    }

    public void GoRight()
    {
        Debug.Log("Executed Server-Toilet Intersection Go Right");
        CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).ServersRoomStateInstance);
    }

    public void GoBackwards()
    {
        Debug.Log("Executed Server-Toilet Intersection Go Backwards");
        CurrentStateMachine.ChangeState(((SceneState)CurrentStateMachine).LobbyStateInstance);
    }
    #endregion
}
