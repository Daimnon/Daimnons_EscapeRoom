public class BaseState
{
    #region Public Fields
    public string Name;
    public string CurrentStateName;
    #endregion

    #region Protected Fields
    protected StateMachine CurrentStateMachine;
    #endregion

    #region Constructor
    public BaseState(string name, StateMachine sM)
    {
        Name = name;
        CurrentStateMachine = sM;
    }
    #endregion

    #region Virtual Methods
    public virtual void Enter() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
    public virtual void Exit() { }
    #endregion

    #region Public Generic Methods
    public BaseState CurrentBaseState<T>() where T : BaseState
    {
        return this;
    }

    public StateMachine CurrentState<T>() where T : StateMachine
    {
        return CurrentStateMachine;
    }
    #endregion
}
