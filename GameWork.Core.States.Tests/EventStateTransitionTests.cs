using System;
using GameWork.Core.States.Tests.TestObjects;
using GameWork.Core.States.Event;
using Xunit;
using EventStateTransition = GameWork.Core.States.Tests.TestObjects.EventStateTransition;

namespace GameWork.Core.States.Tests
{
	public class EventStateTransitionTests
	{
	    private readonly EventStateController _stateController;
	    private readonly EventStateTransition _changeStateTransition;

	    public EventStateTransitionTests()
		{
            _changeStateTransition = new EventStateTransition();

			var eventState1 = new EventState1(_changeStateTransition);

			var eventState2 = new EventState2(_changeStateTransition);

			var eventState3 = new EventState3(_changeStateTransition);

			var states = new EventState[]
			{
			    eventState1, eventState2, eventState3
			};

		    _stateController = new EventStateController(states);
        }
        
        [Theory]
		[InlineData(typeof(EventState1), typeof(EventState2))]
        [InlineData(typeof(EventState2), typeof(EventState3))]
        [InlineData(typeof(EventState3), typeof(EventState1))]
		public void EventTransition(Type fromState, Type toState)
		{
			// Arrange
		    var fromStateName = fromState.FullName;
		    var toStateName = toState.FullName;

			_stateController.Initialize();
			_stateController.EnterState(fromStateName);
			
			// Act
			_changeStateTransition.ChangeState(toStateName);

			// Assert   
			Assert.Equal(toStateName, _stateController.ActiveStateName);
		}
	}
}