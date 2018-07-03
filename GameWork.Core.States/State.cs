namespace GameWork.Core.States
{
	public abstract class State
	{
	    public abstract string Name { get; }

	    public bool IsActive { get; private set; }

        /// <summary>
        /// Called when the state is being Initialized.
        /// Override and add your logic here.
        /// </summary>
        protected virtual void OnInitialize()
		{
		}

	    /// <summary>
	    /// Called when the state is being Terminated.
	    /// Override and add your logic here.
	    /// </summary>
		protected virtual void OnTerminate()
		{
		}

        /// <summary>
        /// Called when the state is being Entered.
        /// Override and add your logic here.
        /// </summary>
        /// <param name="arg"></param>
        protected virtual void OnEnter(object arg)
		{
		}

	    /// <summary>
	    /// Called when the state is being Exited.
	    /// Override and add your logic here.
	    /// </summary>
        protected virtual void OnExit()
		{
		}
        
		internal virtual void Initialize()
		{
			OnInitialize();
		}

		internal virtual void Terminate()
		{
			OnTerminate();
		}

		internal virtual void Enter(string fromStateName, object arg)
		{
			OnEnter(arg);
			IsActive = true;
		}

		internal virtual void Exit(string toStateName)
		{
			OnExit();
			IsActive = false;
		}
	}
}