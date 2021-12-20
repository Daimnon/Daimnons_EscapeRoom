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
    public bool IsCurrentState;

    private Vector2 _mousePos;

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

            case "PhotoToiletIntersection":
                PhotoToiletIntersectionInstance.GoLeft();
                break;

            case "PhotographyRoomState":
                PhotographyRoomStateInstance.GoLeft();
                break;

            case "ToiletsRoomState":
                ToiletsRoomStateInstance.GoLeft();
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

            case "PhotoToiletIntersection":
                PhotoToiletIntersectionInstance.GoRight();
                break;

            case "PhotographyRoomState":
                PhotographyRoomStateInstance.GoRight();
                break;

            case "ToiletsRoomState":
                ToiletsRoomStateInstance.GoRight();
                break;
            default:
                break;
        }
    }
}
