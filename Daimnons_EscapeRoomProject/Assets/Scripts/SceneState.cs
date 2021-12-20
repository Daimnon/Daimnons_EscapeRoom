using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SceneState : StateMachine
{
    public LobbyState LobbyStateInstance;
    public PhotoToiletIntersection PhotoToiletIntersectionInstance;
    public PhotographyRoomState PhotographyRoomStateInstance;
    public ToiletsRoomState ToiletsRoomStateInstance;

    public List<GameObject> InteractableGO;
    public List<Interactable> InteractableGOScripts;
    public Transform MainCamTr, PlayerTr;
    public Button LeftArrowUI, RightArrowUI;

    private void Awake()
    {
        LobbyStateInstance = new LobbyState(this);
        PhotoToiletIntersectionInstance = new PhotoToiletIntersection(this);
        PhotographyRoomStateInstance = new PhotographyRoomState(this);
        ToiletsRoomStateInstance = new ToiletsRoomState(this);
    }

    protected override BaseState GetInitialState()
    {
        return LobbyStateInstance;
    }

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
        StateMachine currentState = GetInitialState().CurrentState<StateMachine>();
        Debug.Log("Executing SceneState Go Left");

        switch (currentState.name)
        {
            case "StateA":
                LobbyStateInstance.GoLeft();
                break;

            case "StateB":
                PhotoToiletIntersectionInstance.GoLeft();
                break;

            case "StateC":
                PhotographyRoomStateInstance.GoLeft();
                break;

            case "StateD":
                ToiletsRoomStateInstance.GoLeft();
                break;
            default:
                break;
        }
    }

    public void GoRight()
    {
        StateMachine currentState = GetInitialState().CurrentState<StateMachine>();
        Debug.Log("Executing SceneState Go Right");

        switch (currentState.name)
        {
            case "StateA":
                LobbyStateInstance.GoRight();
                break;

            case "StateB":
                PhotoToiletIntersectionInstance.GoRight();
                break;

            case "StateC":
                PhotographyRoomStateInstance.GoRight();
                break;

            case "StateD":
                ToiletsRoomStateInstance.GoRight();
                break;
            default:
                break;
        }
    }
}
