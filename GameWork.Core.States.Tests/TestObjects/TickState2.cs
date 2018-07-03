using GameWork.Core.States.Tick;

namespace GameWork.Core.States.Tests.TestObjects
{
	public class TickState2 : TickState
	{
		public static readonly string StateName = typeof(TickState2).FullName;

        public override string Name => StateName;

	    public TickState2(params Tick.TickStateTransition[] stateTransitions) : base(stateTransitions)
	    {
	    }
    }
}
