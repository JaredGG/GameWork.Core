using System.Collections.Generic;
using GameWork.Core.States.Event;

namespace GameWork.Core.States.Tick
{
	public abstract class TickState : EventState
	{
		private readonly List<TickStateTransition> _transitions = new List<TickStateTransition>();
        
		protected TickState(params TickStateTransition[] stateTransitions) : base(stateTransitions)
		{
			_transitions.AddRange(stateTransitions);
		}

	    /// <summary>
	    /// Called when the state is being ticked.
	    /// Override and add your logic here.
	    /// </summary>
        /// <param name="deltaTime"></param>
        protected virtual void OnTick(float deltaTime)
		{
		}
		
		internal virtual void Tick(float deltaTime)
		{
			OnTick(deltaTime);
		}

		internal void TickTransitions(float deltaTime)
		{
			foreach (var transition in _transitions)
			{
				if (transition.DidChangeState(deltaTime))
				{
					break;
				}
			}
		}
	}
}