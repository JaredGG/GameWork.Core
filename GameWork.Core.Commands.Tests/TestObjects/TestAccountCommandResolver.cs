using GameWork.Core.Commands.Accounts;
using GameWork.Core.Commands.Interfaces;

namespace GameWork.Core.Commands.Tests.TestObjects
{
	public class TestAccountCommandResolver : CommandResolver
	{
		private readonly TestAccountContoller _accountController;

		public TestAccountCommandResolver(TestAccountContoller accountContoller)
		{
			_accountController = accountContoller;
		}

		public override void ProcessCommand(ICommand command)
		{
            
		    switch (command)
		    {
		        case RegisterCommand registerCommand:
		            registerCommand.Execute(_accountController);
		            break;

		        case LoginCommand loginCommand:
		            loginCommand.Execute(_accountController);
		            break;

                case LogoutCommand logoutCommand:
		            logoutCommand.Execute(_accountController);
                    break;
            }
		}
	}
}
