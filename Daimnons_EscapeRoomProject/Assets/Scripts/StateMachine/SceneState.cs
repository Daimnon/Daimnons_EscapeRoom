using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SceneState : StateMachine
{
    [SerializeField]
    private DoorManager _doorManagerInstance;

    public LobbyState LobbyStateInstance;
    public ToiletServerIntersectionState ToiletServerIntersectionInstance;
    public ToiletsRoomState ToiletsRoomInstance;
    public ServersRoomState ServersRoomStateInstance;
    public ServersRoomVentState ServersRoomVentStateInstance;
    public TheaterDoorState TheaterDoorStateInstace;
    public TheaterState TheaterStateInstance;

    public List<GameObject> InteractableGO;
    public List<Interactable> InteractableGOScripts;
    public Transform MainCamTr, PlayerTr;
    public Button LeftArrowUI, RightArrowUI;
    public bool IsCurrentState;

    private Vector2 _mousePos;

    private void Awake()
    {
        LobbyStateInstance = new LobbyState(this);
        ToiletServerIntersectionInstance = new ToiletServerIntersectionState(this);
        ToiletsRoomInstance = new ToiletsRoomState(this);
        ServersRoomStateInstance = new ServersRoomState(this);
        ServersRoomVentStateInstance = new ServersRoomVentState(this);
        TheaterDoorStateInstace = new TheaterDoorState(this);
        TheaterStateInstance = new TheaterState(this);
}

    protected override BaseState GetInitialState()
    {
        return LobbyStateInstance;
    }

    public void GoLeft()
    {
        //not returning correct state, returning only 1st state
        BaseState currentState = CurrentState;
        Debug.Log("Executing SceneState Go Left");

        switch (currentState.Name)
        {
            case "LobbyState":
                LobbyStateInstance.GoLeft();
                break;

            case "ToiletServerIntersectionState":
                ToiletServerIntersectionInstance.GoLeft();
                break;

            default:
                break;
        }
    }

    public void GoRight()
    {
        BaseState currentState = CurrentState;
        Debug.Log("Executing SceneState Go Right");

        switch (currentState.Name)
        {
            case "LobbyState":
                LobbyStateInstance.GoRight();
                break;

            case "ToiletServerIntersectionState":
                if (!_doorManagerInstance.IsServersRoomLocked)
                    ToiletServerIntersectionInstance.GoRight();
                else
                    Debug.Log("Get yo key dumbass");
                break;

            //case "ToiletsRoomState":
            //    ToiletsRoomInstance.GoRight();
            //    break;
            //
            //case "ServersRoomState":
            //    ServersRoomStateInstance.GoRight();
            //    break;
            //default:
            //    break;
        }
    }

    public void GoForward()
    {
        BaseState currentState = CurrentState;
        Debug.Log("Executing SceneState Go Forward");

        switch (currentState.Name)
        {
            case "LobbyState":
                LobbyStateInstance.GoForward();
                break;

            case "ServersRoomState":
                ServersRoomStateInstance.GoForward();
                break;

            case "TheaterDoorState":
                TheaterDoorStateInstace.GoForward();
                break;

            default:
                break;
        }
    }

    public void GoBackwards()
    {
        BaseState currentState = CurrentState;
        Debug.Log("Executing SceneState Go Backwards");

        switch (currentState.Name)
        {
            case "ToiletServerIntersectionState":
                ToiletServerIntersectionInstance.GoBackwards();
                break;

            case "ToiletsRoomState":
                ToiletsRoomInstance.GoBackwards();
                break;

            case "ServersRoomState":
                ServersRoomStateInstance.GoBackwards();
                break;
            default:
                break;
        }
    }
}
