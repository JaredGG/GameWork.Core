using System;

namespace GameWork.Core.States.Event
{
	public abstract class EventStateTransition
	{
		internal event Action<string, object> EnterStateEvent;
		internal event Action<string> ExitStateEvent;

	    /// <summary>
	    /// Called when the transition is being Entered.
	    /// Override and add your logic here.
	    /// </summary>
        /// <param name="fromStateName"></param>
        /// <param name="arg"></param>
		protected virtual void OnEnter(string fromStateName, object arg)
		{
		}

        /// <summary>
        /// Called when the transition is being Exited.
        /// Override and add your logic here.
        /// </summary>
        /// <param name="toStateName"></param>
        protected virtual void OnExit(string toStateName)
		{
		}

		protected virtual void EnterState(string toStateName, object arg = null)
		{
			EnterStateEvent?.Invoke(toStateName, arg);
		}

		protected virtual void ExitState(string toStateName)
		{
			ExitStateEvent?.Invoke(toStateName);
		}

		internal virtual void Enter(string fromStateName, object arg)
		{
			OnEnter(fromStateName, arg);
		}

		internal virtual void Exit(string toStateName)
		{
			OnExit(toStateName);
		}
	}
}
