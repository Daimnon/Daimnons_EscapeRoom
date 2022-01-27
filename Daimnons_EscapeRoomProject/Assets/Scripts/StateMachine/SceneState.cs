using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

// Fix library interaction

public class SceneState : StateMachine
{

    public LobbyState LobbyStateInstance;
    public ToiletServerIntersectionState ToiletServerIntersectionInstance;
    public ToiletsRoomState ToiletsRoomInstance;
    public ServersRoomState ServersRoomStateInstance;
    public ServersRoomVentState ServersRoomVentStateInstance;
    public TheaterDoorState TheaterDoorStateInstace;
    public TheaterRoomState TheaterRoomStateInstance;
    public LibraryRoomEntranceState LibraryRoomEntranceStateInstance;
    public LibraryRoomState LibraryRoomStateInstance;

    public List<GameObject> InteractableGO;
    public List<Interactable> InteractableGOScripts;

    [Header("Refrences")]
    [SerializeField] private DoorManager _doorManagerInstance;
    public Transform MainCamTr, PlayerTr;
    public Button LeftArrowUI, RightArrowUI;
    public MouseLook playerMouseLook;

    public bool IsCurrentState;

    private void Awake()
    {
        LobbyStateInstance = new LobbyState(this);
        ToiletServerIntersectionInstance = new ToiletServerIntersectionState(this);
        ToiletsRoomInstance = new ToiletsRoomState(this);
        ServersRoomStateInstance = new ServersRoomState(this);
        ServersRoomVentStateInstance = new ServersRoomVentState(this);
        TheaterDoorStateInstace = new TheaterDoorState(this);
        TheaterRoomStateInstance = new TheaterRoomState(this);
        LibraryRoomEntranceStateInstance = new LibraryRoomEntranceState(this);
        LibraryRoomStateInstance = new LibraryRoomState(this);
    }

    protected override BaseState GetInitialState()
    {
        return LobbyStateInstance;
    }

    public void GoLeft()
    {
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

            case "ServersRoomVentState":
                ServersRoomVentStateInstance.GoRight();
                break;

            case "LibraryRoomState":
                if (_doorManagerInstance.IsLibraryKeyEquipped && !UIManager.Instance.IsLibraryLocked)
                    LibraryRoomStateInstance.GoRight();
                break;

            default:
                break;
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

            case "LibraryRoomEntranceState":
                if (_doorManagerInstance.IsLibraryKeyEquipped && !UIManager.Instance.IsLibraryLocked)
                    LibraryRoomEntranceStateInstance.GoForward();
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

            case "TheaterDoorState":
                TheaterDoorStateInstace.GoBackwards();
                break;

            case "TheaterRoomState":
                TheaterRoomStateInstance.GoBackwards();
                break;

            case "LibraryRoomEntranceState":
                LibraryRoomEntranceStateInstance.GoForward();
                break;

            case "LibraryRoomState":
                LibraryRoomStateInstance.GoBackwards();
                break;
                
            default:
                break;
        }
    }
}
