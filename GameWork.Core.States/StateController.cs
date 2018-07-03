using System;
using System.Collections.Generic;
using System.Linq;

namespace GameWork.Core.States
{
	public class StateController : StateController<State>
	{
		public StateController(params State[] states) : base(states)
		{
		}
	}

	public class StateController<TState> : IStateController
		where TState : State
	{
	    protected readonly Dictionary<string, TState> States;
	    protected bool IsProcessingStateChange;
	    protected string LastActiveStateName;
	    protected IStateController ParentController;

	    public string ActiveStateName { protected set; get; }

        public StateController(params TState[] states)
        {
            States = states.ToDictionary(
                s => s.Name, 
                s => s);
		}

        public void Initialize()
		{
			foreach (var state in States.Values)
			{
				state.Initialize();
			}

			OnInitialize();
		}

		public void Terminate()
		{
			OnTerminate();

			if (ActiveStateName != null)
			{
				States[ActiveStateName].Exit(null);
			}

			foreach (var state in States.Values)
			{
				state.Terminate();
			}
		}

	    /// <summary>
	    /// Called when the controller is being initialized.
	    /// Override and add your logic here.
	    /// </summary>
		protected virtual void OnInitialize()
		{
		}

	    /// <summary>
	    /// Called when the controller is being terminated.
	    /// Override and add your logic here.
	    /// </summary>
		protected virtual void OnTerminate()
		{
		}

		public virtual void ExitState(string toStateName)
		{
			IsProcessingStateChange = true;

			if (ActiveStateName != null)
			{
				LastActiveStateName = ActiveStateName;
				ActiveStateName = null;
				States[LastActiveStateName].Exit(toStateName);
			}

			if (!States.ContainsKey(toStateName))
			{
				if (ParentController != null)
				{
					ParentController.ExitState(toStateName);
				}
				else
				{
					throw new ArgumentOutOfRangeException($"No state with the name: {toStateName} was found" +
															$"There is also no parent {nameof(StateController)} set, which may also resolve the state change.");
				}
			}
		}

		public virtual void EnterState(string toStateName, object arg = null)
		{
			if (States.ContainsKey(toStateName))
			{
				States[toStateName].Enter(LastActiveStateName, arg);
				ActiveStateName = toStateName;
			}
			else if (ParentController != null)
			{
			    ParentController.EnterState(toStateName);
            }
			else
			{
			    throw new ArgumentOutOfRangeException($"No state with the name: {toStateName} was found" +
			                                          $"There is also no parent {nameof(StateController)} set, which may also resolve the state change.");
			}

			IsProcessingStateChange = false;
		}
	}
}