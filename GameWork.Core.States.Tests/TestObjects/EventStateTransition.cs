namespace GameWork.Core.States.Tests.TestObjects
{
    public class EventStateTransition : Event.EventStateTransition
    {
        public void ChangeState(string toStateName)
        {
            ExitState(toStateName);
            EnterState(toStateName);
        }
    }
}
