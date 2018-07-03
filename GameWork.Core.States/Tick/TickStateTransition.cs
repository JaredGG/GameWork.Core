using GameWork.Core.States.Event;

namespace GameWork.Core.States.Tick
{
	public abstract class TickStateTransition : EventStateTransition
	{
		private bool _didChangeState;
		protected abstract void OnTick(float deltaTime);

		protected override void ExitState(string toStateName)
		{
			_didChangeState = true;
			base.ExitState(toStateName);
		}

		internal override void Enter(string fromStateName, object arg)
		{
			_didChangeState = false;
			base.Enter(fromStateName, arg);
		}

		internal bool DidChangeState(float deltaTime)
		{
			OnTick(deltaTime);

			return _didChangeState;
		}
	}
}