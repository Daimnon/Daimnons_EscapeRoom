using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SceneState : StateMachine
{
    public LobbyState LobbyStateInstance;
    public ServerToiletIntersectionState ToiletServerIntersectionInstance;
    public ToiletsRoomState ToiletsRoomInstance;
    public ServersRoomState ServersRoomStateInstance;

    public List<GameObject> InteractableGO;
    public List<Interactable> InteractableGOScripts;
    public Transform MainCamTr, PlayerTr;
    public Button LeftArrowUI, RightArrowUI;
    public bool IsCurrentState;

    private Vector2 _mousePos;

    private void Awake()
    {
        LobbyStateInstance = new LobbyState(this);
        ToiletServerIntersectionInstance = new ServerToiletIntersectionState(this);
        ToiletsRoomInstance = new ToiletsRoomState(this);
        ServersRoomStateInstance = new ServersRoomState(this);
    }

    protected override BaseState GetInitialState()
    {
        return LobbyStateInstance;
    }

    //protected override BaseState C

    public void Interact<T>()
    {
        foreach (GameObject item in InteractableGO)
        {
            if (item.GetComponent<Interactable>().IsInteracting)
            {
                /* need to think of a way to run all Interact()
                 * in a script with the name of the GO */
                
                //item.GetComponent<Interactable>().Interact();
            }                

        }
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

            case "ServerToiletIntersectionState":
                ToiletServerIntersectionInstance.GoLeft();
                break;

            case "ToiletsRoomState":
                ToiletsRoomInstance.GoLeft();
                break;

            case "ServersRoomState":
                ServersRoomStateInstance.GoLeft();
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

            case "ServerToiletIntersectionState":
                ToiletServerIntersectionInstance.GoRight();
                break;

            case "ToiletsRoomState":
                ToiletsRoomInstance.GoRight();
                break;

            case "ServersRoomState":
                ServersRoomStateInstance.GoRight();
                break;
            default:
                break;
        }
    }
}
