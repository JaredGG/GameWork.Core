using System;
using GameWork.Core.States.Tests.TestObjects;
using GameWork.Core.States.Tick;
using Xunit;
using TickStateTransition = GameWork.Core.States.Tests.TestObjects.TickStateTransition;

namespace GameWork.Core.States.Tests
{
	public class TickStateTransitionTests
	{
		private readonly TickStateTransitionBlackboard _tickStateTransitionBlackboard;
	    private readonly TickStateController _stateController;

		public TickStateTransitionTests()
		{
		    _tickStateTransitionBlackboard = new TickStateTransitionBlackboard();

			var tickState1 = new TickState1(new TickStateTransition(TickState2.StateName, _tickStateTransitionBlackboard));

			var tickState2 = new TickState2(new TickStateTransition(TickState3.StateName, _tickStateTransitionBlackboard));

			var tickState3 = new TickState3(new TickStateTransition(TickState1.StateName, _tickStateTransitionBlackboard));

			var states = new TickState[]
			{
			    tickState1, tickState2, tickState3
			};

		    _stateController = new TickStateController(states);
        }
        
        [Theory]
        [InlineData(typeof(TickState1), typeof(TickState2))]
        [InlineData(typeof(TickState2), typeof(TickState3))]
        [InlineData(typeof(TickState3), typeof(TickState1))]
        public void TickTransition(Type fromState, Type toState)
        {
            // Arrange
            var fromStateName = fromState.FullName;
            var toStateName = toState.FullName;
			_stateController.Initialize();
			_stateController.EnterState(fromStateName);
			_tickStateTransitionBlackboard.ToStateName = toStateName;

			// Act
			_stateController.Tick(0f);

			// Assert   
			Assert.Equal(toStateName, _stateController.ActiveStateName);
		}
	}
}