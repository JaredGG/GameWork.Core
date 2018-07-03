using GameWork.Core.States.Event;

namespace GameWork.Core.States.Tests.TestObjects
{
	public class EventState3 : EventState
	{
	    public static readonly string StateName = typeof(EventState3).FullName;

        public override string Name => StateName;

	    public EventState3(params Event.EventStateTransition[] stateTransitions) : base(stateTransitions)
	    {
	    }
    }
}
