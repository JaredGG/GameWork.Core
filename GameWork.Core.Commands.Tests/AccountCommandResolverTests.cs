using GameWork.Core.Commands.Accounts;
using GameWork.Core.Commands.Tests.TestObjects;
using Xunit;

namespace GameWork.Core.Commands.Tests
{
	public class AccountCommandResolverTests
	{
		private const string Username = "testUser";
		private const string Password = "testPassword";

		private readonly TestAccountContoller _accountContoller = new TestAccountContoller(Username, Password);
		private readonly TestAccountCommandResolver _commandResolver;

		public AccountCommandResolverTests()
		{
			_commandResolver = new TestAccountCommandResolver(_accountContoller);
		}

		[Fact]
		public void Register()
		{
            // Arrange
			Assert.False(_accountContoller.IsRegistered);
			var command = new RegisterCommand(Username, Password);

            // Act
			_commandResolver.ProcessCommand(command);

            // Assert
			Assert.True(_accountContoller.IsRegistered);
		}

		[Fact]
		public void Login()
		{
            // Arrange
			Assert.False(_accountContoller.IsLoggedIn);
			var command = new LoginCommand(Username, Password);

            // Act
			_commandResolver.ProcessCommand(command);

            // Assert
			Assert.True(_accountContoller.IsLoggedIn);
		}

		[Fact]
		public void Logout()
		{
            // Arrange
			Assert.False(_accountContoller.IsLoggedOut);
			var command = new LogoutCommand();

            // Act
			_commandResolver.ProcessCommand(command);

            // Assert
			Assert.True(_accountContoller.IsLoggedOut);
		}
	}
}