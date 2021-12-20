using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SceneState : StateMachine
{
    public StateA StateAInstance;
    public StateB StateBInstance;
    public StateC StateCInstance;
    public StateD StateDInstance;

    public List<GameObject> InteractableGO;
    public List<Interactable> InteractableGOScripts;
    public Transform MainCamTr, PlayerTr;
    public Button LeftArrowUI, RightArrowUI;

    private void Awake()
    {
        StateAInstance = new StateA(this);
        StateBInstance = new StateB(this);
        StateCInstance = new StateC(this);
        StateDInstance = new StateD(this);
    }

    protected override BaseState GetInitialState()
    {
        return StateAInstance;
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
                StateAInstance.GoLeft();
                break;

            case "StateB":
                StateBInstance.GoLeft();
                break;

            case "StateC":
                StateCInstance.GoLeft();
                break;

            case "StateD":
                StateDInstance.GoLeft();
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
                StateAInstance.GoRight();
                break;

            case "StateB":
                StateBInstance.GoRight();
                break;

            case "StateC":
                StateCInstance.GoRight();
                break;

            case "StateD":
                StateDInstance.GoRight();
                break;
            default:
                break;
        }
    }
}
