﻿using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using OpenGoldenSunWindows.Characters;
using OpenGoldenSunWindows.Gui;
using OpenGoldenSunWindows.Utils;

namespace OpenGoldenSunWindows.Gui.StatusScreen
{
    public class StatusScreenController : ControllerBase
    {
        // A random selection of colors
        Color[] colors = { 
            WindowManager.DefaultColor, Color.Aqua, Color.DarkGray, Color.Honeydew, 
            Color.HotPink, Color.MintCream, Color.CornflowerBlue, Color.Chartreuse, 
            Color.BurlyWood, Color.Gold, Color.Gainsboro, Color.Teal, Color.Wheat };
        int currentColor;

        ObservableReference<int> cursorPosition;
        ObservableReference<Character> selectedCharacter;
        Party party;

        public StatusScreenController (ObservableReference<int> cursorPosition, ObservableReference<Character> selectedCharacter, Party party) : base()
        {
            this.currentColor = 0;
            this.cursorPosition = cursorPosition;
            this.selectedCharacter = selectedCharacter;
            this.party = party;
        }

        private void MoveCursor(int offset)
        {
            var count = party.Characters.Count;
            cursorPosition.Value = (cursorPosition.Value + count + offset) % count;

            var character = party.Characters [cursorPosition.Value];
            selectedCharacter.Value = character;
        }
            
        private void CycleColor(int offset)
        {
            var length = colors.Length;
            currentColor = (currentColor + length + offset) % length;
            WindowManager.Color = colors [currentColor];
        }


        public override void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState ();

            if (WasPressed(state, Keys.Left)) {
                MoveCursor (-1);
            } else if (WasPressed(state, Keys.Right)) {
                MoveCursor (1);
            }

            if (WasPressed (state, Keys.Up)) {
                CycleColor (1);
            } else if (WasPressed (state, Keys.Down)) {
                CycleColor (-1);
            }

            if (WasPressed (state, Keys.A)) {
                ScreenManager.ChangeScreen (Screens.Menu);
            }

            if (WasPressed (state, Keys.R)) {
                party.RemoveCharacter (0);
                if (cursorPosition.Value == party.Characters.Count)
                    cursorPosition.Value--;
                selectedCharacter.Value = party.Characters [cursorPosition.Value];
            }

            UpdateKeyboardState (state);
        }

        public override void Reset ()
        {
            cursorPosition.Value = 0;
            selectedCharacter.Value = party.Characters [cursorPosition.Value];
        }
    }
}

