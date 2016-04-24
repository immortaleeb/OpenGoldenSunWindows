using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using OpenGoldenSunWindows.Utils;

namespace OpenGoldenSunWindows.Gui.DjinnScreen
{
    public class MainDjinnScreenController : ControllerBase
    {
        public MainDjinnScreenController ()
        {
        }

        public override void Update (GameTime gametime)
        {
            KeyboardState state = Keyboard.GetState ();

            if (WasPressed (state, Controls.CancelKey)) {
                ScreenManager.ChangeScreen (Screens.Menu);
            }

            UpdateKeyboardState (state);
        }

        public override void Reset ()
        {
        }
    }
}

