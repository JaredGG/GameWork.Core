using GameWork.Core.States.Input;

namespace GameWork.Core.States.Event.Input
{
	public abstract class InputEventState : InputEventState<StateInput>
	{
		protected InputEventState(StateInput stateInput) : base(stateInput)
		{
		}
	}

    public abstract class InputEventState<TStateInput> : EventState
        where TStateInput : StateInput
    {
        private readonly TStateInput _eventStateInput;

        protected InputEventState(TStateInput eventStateInput, params EventStateTransition[] transitions) : base(transitions)
        {
            _eventStateInput = eventStateInput;
        }

        internal override void Initialize()
        {
            base.Initialize();
            _eventStateInput.Initialize();
        }

        internal override void Terminate()
        {
            _eventStateInput.Terminate();
            base.Terminate();
        }

        internal override void Enter(string fromStateName, object arg)
        {
            base.Enter(fromStateName, arg);
            _eventStateInput.Enter(fromStateName);
        }

        internal override void Exit(string toStateName)
        {
            _eventStateInput.Exit(toStateName);
            base.Exit(toStateName);
        }
    }
}