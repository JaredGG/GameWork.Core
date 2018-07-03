namespace GameWork.Core.States.Tests.TestObjects
{
    public class TickStateTransition : Tick.TickStateTransition
    {
        private readonly TickStateTransitionBlackboard _transitionBlackboard;
	    private readonly string _toStateName;

        public TickStateTransition(string toStateName, TickStateTransitionBlackboard transitionBlackboard)
        {
            _toStateName = toStateName;
            _transitionBlackboard = transitionBlackboard;
        }

		protected override void OnTick(float deltaTime)
		{
			if (_toStateName == _transitionBlackboard.ToStateName)
			{
				ExitState(_toStateName);	
				EnterState(_toStateName);
			}
		}
	}
}
