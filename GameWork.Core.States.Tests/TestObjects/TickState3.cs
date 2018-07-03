using GameWork.Core.States.Tick;

namespace GameWork.Core.States.Tests.TestObjects
{
	public class TickState3 : TickState
	{
	    public static readonly string StateName = typeof(TickState3).FullName;

        public override string Name => StateName;

	    public TickState3(params Tick.TickStateTransition[] stateTransitions) : base(stateTransitions)
	    {
	    }
    }
}
