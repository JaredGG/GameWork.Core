# Overview
Common Game State and State Controller functionality.

# Concepts
## State
The object that contains the state logic. At the very base this has an OnInitialize, OnTerminate, OnEnter and OnExit.

## State Controller
The states get added to the controller which does the actual state switching.

## State Transition
These trigger the transition between states. Each state can have transitions added to it. A transition only comes into effect when the state it was added to is the active state.

## State Input
These are similar to the States but are for any controlling logic. The idea is to put any game logic in the State and any input controller, keyboard, UI etc logic in the StateInput.

## Input State
The base State doesn't handle StateInput so an InputState is required.

# Type hierarchy
- **State**: *base state type.* 
- **StateController**: *base state controller type.*
- **StateInput**: *Input for a state.*
- **InputState**: *State that has a StateInput.*
  - **EventState**: *Event driven state.*
  - **EventStateController**: *Controller for event driven states.*
  - **EventStateTransition**: *Event driven transitions.*
  - **InputEventState**: *Event state that has StateInput*
    - **TickState**: *State that is Ticked.*
    - **TickStateController**: *Controller for states that are Ticked.*
    - **TickStateTransition**: *Transition that is Ticked.*
    - **InputTickState**: *Tick state that has StateInput which is Ticked. It has a take only command queue that is to be written to from the TickStateInput and taken from in this state containing the game logic.*
    - **TickStateInput**: *StateInput that is Ticked. It has a write only command queue that is to be written to from this state and taken from in the InputTickState containing the game logic.*
    
**Note:** Because this is a hierarchy, all the derived items incorporate all the functionality of their deriving types. 

So a TickState can have EventStateTransitions added to it.

# Usage
1. Create your states (Optional: and state inputs):  
1.1. Optional: Create the state input.  
1.2. Create the transitions for this state.  
1.3. Create the state, passing in the transitions (Optional: and the state input).  

2. Add the states to the state controller.

See the Tests project for example usage.

## Hierarchical States
For simplicity states transitions are only able to change between sibling states. 

A hierarchical state structure can be achieved by implementing the following:

1. In a state's (we'll call this the parent state) OnEnter, create your sub states, transitions and the sub state controller.  
2. Call the sub state controller's OnInitialize in the parent state's OnEnter and it's OnTerminate in the parent state's OnExit.  
This means this controller's lifespan is limited to the time the parent state is active.

3. Add a transition to the parent state's state controller that transitions it to whichever parent sibling state your interested in when some condition is met. 

This could be via a global message queue that is shared between the parent states, sub states and parent state transitions. 

In this scenario, a child state would write to the message queue. The parent state transition would listen for the specific message and when recieved, change the parent state to a sobling parent state.  

With the sub state controller setup in the recommended way, it would be terminated, exiting all sub states when the parent state is exited.

This method has the benefit of being both flexible and transparent.

### Example

Imagine the following hierarchy:

- **RootStateController**
  - **GameLobbyState**
  - **BattleState**: *contains the BattleSimulator.*
    - **BattleSubStateController**
      - **PlayingState**
      - **PausedState**
      - **GameOverState**
  - **SettingState**
  - **ShopState**

The switching from **PlayingState** to **PausedState** is triggered by a transition that was added to the **PlayingState** which is triggered when the player presses the *battle-pause* button. This transition tells the **BattleSubStateController** to perform the switch.

Switching from **PlayingState** to **GameOverState** is triggered by another transition that was added to the **PlayingState** which is triggered when the **BattleSimulator** broadcasts that the *battle-over* message. This transition tells the **BattleSubStateController** to perform the switch.

Now when the player presses the *game-over-continue* button while in the **GameOverState**, a transition that has been added to **BattleState** is triggered which tells the **RoomStateController** to switch states to the **GameLobbyState**.

This works because the parent state's (**BattleState**) transitions are still active while it's sub states are being processed. 

State switching in the **BattleSubStateController**:  
|  |  |  | Transition Trigger Condition|
| - | - | - | - |
**GameLobbyState** | -> | **BattleState** | player pressed *start-battle* button. 
**GameLobbyState** | <- | **BattleState** | player pressed *game-over-continue* button.
**GameLobbyState** | -> | **SettingState** | player pressed *open-settings* button.
**GameLobbyState** | <- | **SettingState** | player pressed *close-settings* button.
**GameLobbyState** | -> | **ShopState** | player pressed *open-shop* button.
**GameLobbyState** | <- | **ShopState** | player pressed *close-shop* button.

 State switching in the **BattleSubStateController**:  
|  |  |  | Transition Trigger Condition|
| - | - | - | - |
**PlayingState** | -> | **PausedState** | player pressed *battle-pause* button.    
**PlayingState** | <- | **PausedState** | player pressed *battle-resume* button.
**PlayingState** | -> | **GameOverState** | **BattleSimulator** broadcasts *battle-over* message.