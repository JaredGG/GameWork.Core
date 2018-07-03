namespace GameWork.Core.States.Input
{
	public class StateInput : StateInput<State>
	{
	}
	
	public class StateInput<TState>
		where TState : State
	{
		protected TState State { get; private set; }

		internal void SetState(TState state)
		{
			State = state;
		}

	    /// <summary>
	    /// Called when the state is being initialized.
	    /// Override and add your logic here.
	    /// </summary>
	    protected virtual void OnInitialize()
	    {
	    }

	    /// <summary>
	    /// Called when the state is being terminated.
	    /// Override and add your logic here.
	    /// </summary>
	    protected virtual void OnTerminate()
	    {
	    }

	    /// <summary>
	    /// Called when the state is being entered.
	    /// Override and add your logic here.
	    /// </summary>
	    protected virtual void OnEnter()
	    {
	    }

	    /// <summary>
	    /// Called when the state is being exited.
	    /// Override and add your logic here.
	    /// </summary>
	    protected virtual void OnExit()
	    {
	    }

        internal void Initialize()
		{
			OnInitialize();
		}

		internal void Terminate()
		{
			OnTerminate();
		}

		internal void Enter(string fromStateName)
		{
			OnEnter();
		}

		internal void Exit(string toStateName)
		{
			OnExit();
		}
	}
}
