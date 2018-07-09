using System.Collections.Generic;

namespace GameWork.Core.States.Event
{
	public abstract class EventState : State
	{
		private readonly List<EventStateTransition> _transitions = new List<EventStateTransition>();

	    protected EventState(params EventStateTransition[] stateTransitions)
	    {
	        _transitions.AddRange(stateTransitions);
        }
        
		internal override void Enter(string fromStateName, object arg)
		{
			base.Enter(fromStateName, arg);
			_transitions.ForEach(t => t.Enter(fromStateName, arg));
		}

		internal override void Exit(string toStateName)
		{
			_transitions.ForEach(t => t.Exit(toStateName));
			base.Exit(toStateName);
		}

		internal void ConnectTransitions(IStateController stateController)
		{
			foreach (var transition in _transitions)
			{
				transition.ExitStateEvent += stateController.ExitState;
				transition.EnterStateEvent += stateController.EnterState;
			}
		}

		internal void DisconnectTransisions(IStateController stateController)
		{
			foreach (var transition in _transitions)
			{
				transition.ExitStateEvent -= stateController.ExitState;
				transition.EnterStateEvent -= stateController.EnterState;
			}
		}
	}
}