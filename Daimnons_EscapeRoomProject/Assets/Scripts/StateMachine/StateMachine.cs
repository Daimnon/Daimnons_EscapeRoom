using UnityEngine;

public class StateMachine : MonoBehaviour
{
    #region Fields
    private BaseState _currentState;
    #endregion

    #region Properties
    public BaseState CurrentState { get => _currentState; }
    #endregion

    #region Unity Callbacks
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
    #endregion

    #region Virtual Methods
    protected virtual BaseState GetInitialState()
    {
        return null;
    }
    #endregion

    #region Methods
    public void ChangeState(BaseState newState)
    {
        _currentState.Exit();

        _currentState = newState;
        _currentState.Enter();
    }
    #endregion

    #region Testings
    private void OnGUI()
    {
        string txt = _currentState != null ? _currentState.Name : "(No Current State)";
        GUILayout.Label($"<color='black'><size=40>{txt}</size></color>");
    }
    #endregion
}
