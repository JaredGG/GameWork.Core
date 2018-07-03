using System;
using System.Collections.Generic;
using System.Text;

namespace GameWork.Core.States.Input
{
    public abstract class InputState : InputState<StateInput>
    {
        protected InputState(StateInput stateInput) : base(stateInput)
        {
        }
    }

    public abstract class InputState<TStateInput> : State
        where TStateInput : StateInput
    {
        internal readonly TStateInput StateInput;

        protected InputState(TStateInput stateInput)
        {
            StateInput = stateInput;
        }
    }
}
