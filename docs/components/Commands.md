# Overview
Commands, Command Queue and Command Resolver.

# Usage
1. Create your controller that contains the business logic you want to turn into commands.

2. For a discrete method you wish to call:  
2.1. Create an extension of ICommandAction that contains that specific method signature.  
2.2 Add the newly extended ICommandAction to your controllers implemented interfaces.  
2.3. Extend ICommand using your ICommandAction as the generic type.    
2.3.1. Set the constructor to take in an store the parameters required by your extended ICommandAction.  
2.3.1.  Implement the Execute method, taking in the ICommandAction you extended and executing its only method, passing in the parameters your took in in the constructor.    

3. Extend the CommandResolver:  
3.1. Pass your controller into the command resolver's constructor.  
3.2. Override the ProcessCommands method, converting the incomming command to its concrete type and calling its execute method, passing in your controller that extends the various command actions.

4. Create a CommandQueue, give it some commands and then pass it to your CommandResolver.

Note: Take a look at the Test project for usage examples.