using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private BaseState _currentState;
    void Start()
    {
        _currentState = GetInitialState();

        if (_currentState != null)
            _currentState.Enter();
    }

    void Update()
    {
        if (_currentState != null)
            _currentState.UpdateLogic();
    }

    private void LateUpdate()
    {

        if (_currentState != null)
            _currentState.UpdatePhysics();
    }

    public void ChangeState(BaseState newState)
    {
        _currentState.Exit();

        _currentState = newState;
        _currentState.Enter();
    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    private void OnGUI()
    {
        string txt = _currentState != null ? _currentState.Name : "(No Current State)";
        GUILayout.Label($"<color='black'><size=40>{txt}</size></color>");
    }
}
