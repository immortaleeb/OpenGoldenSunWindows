using System;
using OpenGoldenSunWindows.Utils;
using OpenGoldenSunWindows.Characters;
using Microsoft.Xna.Framework;

namespace OpenGoldenSunWindows.Gui.DjinnScreen
{
    public class DjinniInfoWindow : WindowBase, IObserver
    {
        private ObservableReference<Character> selectedCharacter;
        private ObservableReference<Djinni> selectedDjinni;

        private GuiItem[] helpItems;

        public DjinniInfoWindow (ObservableReference<Character> selectedCharacter, ObservableReference<Djinni> selectedDjinni, int x, int y) : base (x, y, 136, 40)
        {
            this.selectedCharacter = selectedCharacter;
            this.selectedDjinni = selectedDjinni;

            GenerateHelpItems ();

            selectedDjinni.Register (this);
            OnEvent (selectedDjinni);
        }

        private void GenerateHelpItems ()
        {
            helpItems = new GuiItem[7];
            Add (helpItems [0] = new TextLabel ("Choose a Djinni.", new Vector2 (X + 8, Y + 8)));
            Add (helpItems [1] = new IconLabel (Icons.RButton, new Vector2 (X + 8, Y + 24)));
            Add (helpItems [2] = new TextLabel (":", new Vector2 (X + 23, Y + 24)));
            Add (helpItems [3] = new TextLabel ("Standby", new Vector2 (X + 27, Y + 24)));
            Add (helpItems [4] = new IconLabel (Icons.SelectButton, new Vector2 (X + 73, Y + 24)));
            Add (helpItems [5] = new TextLabel (":", new Vector2 (X + 86, Y + 24)));
            Add (helpItems [6] = new TextLabel ("Help", new Vector2 (X + 90, Y + 24)));
        }

        public void OnEvent (IObservable source)
        {
            var djinni = selectedDjinni.Value;
            if (djinni == null) {
                // TODO make help items visible
            } else {
                // TODO make help items invisible
            }
        }
    }
}

