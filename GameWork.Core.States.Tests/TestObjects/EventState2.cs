using GameWork.Core.States.Event;

namespace GameWork.Core.States.Tests.TestObjects
{
	public class EventState2 : EventState
	{
	    public static readonly string StateName = typeof(EventState2).FullName;

        public override string Name => StateName;

	    public EventState2(params Event.EventStateTransition[] stateTransitions) : base(stateTransitions)
	    {
	    }
    }
}
