using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace OpenGoldenSunWindows.Gui
{
    public abstract class ControllerBase : Controller
    {
        KeyboardState oldState;

        public ControllerBase ()
        {
            this.oldState = Keyboard.GetState ();
        }

        protected bool WasPressed(KeyboardState state, Keys key)
        {
            return state.IsKeyUp (key) && !oldState.IsKeyUp (key);
        }

        protected void UpdateKeyboardState(KeyboardState state)
        {
            this.oldState = state;
        }

        public abstract void Update (GameTime gametime);
    }
}

