using System.Collections.Generic;
using GameWork.Core.Commands.Interfaces;
using GameWork.Core.Commands.Tests.TestObjects;
using Xunit;

namespace GameWork.Core.Commands.Tests
{
	public class CommandResolverTests
	{
		[Fact]
		public void ResolveSingleCommand()
		{
			// Arrange
			var values = new List<string>()
			{
				"Hannah",
				"Bob",
				"Frank",
				"Franchesca",
				"Zoltan"
			};

			var testCollection = new TestCollection<string>();
			var testCollectionCommandResolver = new TestCollectionCommandResolver<string>(testCollection);

			Assert.Empty(testCollection); 
			
			// Act
			foreach (var value in values)
			{
				testCollectionCommandResolver.ProcessCommand(new AddToTestCollectionCommand<string>(value));
			}

			// Assert
			Assert.Equal(values.Count, testCollection.Count);
			Assert.Equal(values, testCollection);
		}

		[Fact]
		public void ResolveMultipleCommands()
		{
			// Arrange
			var values = new List<string>()
			{
				"Hannah",
				"Bob",
				"Frank",
				"Franchesca",
				"Zoltan"
			};

			var testCollection = new TestCollection<string>();
			var testCollectionCommandResolver = new TestCollectionCommandResolver<string>(testCollection);

			Assert.Empty(testCollection);

			var commands = new List<ICommand>();
			foreach (var value in values)
			{
				commands.Add(new AddToTestCollectionCommand<string>(value));
			}

			// Act
			testCollectionCommandResolver.ProcessCommands(commands);

			// Assert
			Assert.Equal(values.Count, testCollection.Count);
		    Assert.Equal(values, testCollection);
		}

		[Fact]
		public void ResolveCommandQueue()
		{
			// Arrange
			var values = new List<string>()
			{
				"Hannah",
				"Bob",
				"Frank",
				"Franchesca",
				"Zoltan"
			};

			var commandQueue = new CommandQueue();

		    foreach (var value in values)
		    {
		        commandQueue.AddCommand(new AddToTestCollectionCommand<string>(value));
		    }

		    var testCollection = new TestCollection<string>();
		    var testCollectionCommandResolver = new TestCollectionCommandResolver<string>(testCollection);

		    Assert.Empty(testCollection);

            // Act
            testCollectionCommandResolver.ProcessCommandQueue(commandQueue);

            // Assert
            Assert.Equal(values.Count, testCollection.Count);
			Assert.Equal(values, testCollection);
		}
	}
}
