using GameWork.Core.Commands;
using GameWork.Core.Commands.Interfaces;

namespace GameWork.Core.States.Tick.Input
{
	public abstract class InputTickState : InputTickState<TickStateInput>
	{
		protected InputTickState(TickStateInput tickStateInput) : base(tickStateInput)
		{
		}
	}

	public abstract class InputTickState<TStateInput> : TickState
		where TStateInput : TickStateInput
	{
		private readonly ICommandQueue _commandQueue;
		private readonly TStateInput _tickStateInput;

		protected ICommandQueueTake CommandQueue => _commandQueue;

		protected InputTickState(TStateInput tickStateInput, params TickStateTransition[] transitions) : base(transitions)
		{
			_tickStateInput = tickStateInput;
			_commandQueue = new CommandQueue();
			_tickStateInput.SetCommandQueue(_commandQueue);
		}	

		internal override void Initialize()
		{
			base.Initialize();
			_tickStateInput.Initialize();
		}

		internal override void Terminate()
		{
			_tickStateInput.Terminate();
			base.Terminate();
		}

		internal override void Enter(string fromStateName, object arg)
		{
			base.Enter(fromStateName, arg);
			_tickStateInput.Enter(fromStateName);
		}

		internal override void Exit(string toStateName)
		{
			_tickStateInput.Exit(toStateName);
			base.Exit(toStateName);
		}

		internal override void Tick(float deltaTime)
		{
			_tickStateInput.Tick(deltaTime);
			base.Tick(deltaTime);
		}
	}
}