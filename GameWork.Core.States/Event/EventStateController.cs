namespace GameWork.Core.States.Event
{
    public class EventStateController : EventStateController<EventState>
    {
        public EventStateController(params EventState[] states) : base(states)
        {
        }
    }

    public class EventStateController<TEventState> : StateController<TEventState>
		where TEventState : EventState  
	{
		public EventStateController(params TEventState[] states) : base(states)
		{
		}
		
		public override void EnterState(string toStateName, object arg = null)
		{
			if (LastActiveStateName != null)
			{
				States[LastActiveStateName].DisconnectTransisions(this);
			}

			if (States.ContainsKey(toStateName))
			{
				States[toStateName].ConnectTransitions(this);
			}

			base.EnterState(toStateName, arg);
		}
	}
}