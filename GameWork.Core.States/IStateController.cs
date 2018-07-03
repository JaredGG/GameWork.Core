namespace GameWork.Core.States
{
	public interface IStateController
	{
        string ActiveStateName { get; }

	    void Initialize();

	    void Terminate();

	    void ExitState(string toStateName);

	    void EnterState(string toStateName, object arg = null);
    }
}
