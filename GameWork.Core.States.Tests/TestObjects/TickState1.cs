using GameWork.Core.States.Tick;

namespace GameWork.Core.States.Tests.TestObjects
{
	public class TickState1 : TickState
	{
	    public static readonly string StateName = typeof(TickState1).FullName;

        public override string Name => StateName;

	    public TickState1(params Tick.TickStateTransition[] stateTransitions) : base(stateTransitions)
	    {
	    }
    }
}
