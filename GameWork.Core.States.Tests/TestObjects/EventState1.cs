using GameWork.Core.States.Event;

namespace GameWork.Core.States.Tests.TestObjects
{
	public class EventState1 : EventState
	{
	    public static readonly string StateName = typeof(EventState1).FullName;

        public override string Name => StateName;

	    public EventState1(params Event.EventStateTransition[] stateTransitions) : base(stateTransitions)
	    {
	    }
    }
}
