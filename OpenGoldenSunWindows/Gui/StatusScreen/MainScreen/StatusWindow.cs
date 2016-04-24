using System;
using System.Linq;
using OpenGoldenSunWindows.Utils;
using OpenGoldenSunWindows.Characters;
using Microsoft.Xna.Framework;
using OpenGoldenSunWindows.Animations;
using Microsoft.Xna.Framework.Graphics;

namespace OpenGoldenSunWindows.Gui.StatusScreen.MainScreen
{
    public class StatusWindow : StatusWindowBase
    {
        IntegerLabel earthDjinn;
        IntegerLabel waterDjinn;
        IntegerLabel fireDjinn;
        IntegerLabel windDjinn;
        
        public StatusWindow (ObservableReference<Character> selectedCharacter, int x, int y) : base (selectedCharacter, x, y)
        {
            Add (new TextLabel ("Djinn", new Vector2 (X + 72, Y + 96)));
            Add (earthDjinn = new IntegerLabel (new Vector2 (X + 136, Y + 96)));
            Add (waterDjinn = new IntegerLabel (new Vector2 (X + 168, Y + 96)));
            Add (fireDjinn = new IntegerLabel (new Vector2 (X + 200, Y + 96)));
            Add (windDjinn = new IntegerLabel (new Vector2 (X + 232, Y + 96)));

            Add (new IconLabel (Icons.Venus, new Vector2 (X + 129, Y + 89)));
            Add (new IconLabel (Icons.Mercury, new Vector2 (X + 161, Y + 89)));
            Add (new IconLabel (Icons.Mars, new Vector2 (X + 193, Y + 89)));
            Add (new IconLabel (Icons.Jupiter, new Vector2 (X + 225, Y + 89)));

            // Djinn animations
            Add (new WalkingDjinniAnimation (Element.Earth, new Vector2 (X + 115, Y + 58), SpriteEffects.FlipHorizontally));
            Add (new WalkingDjinniAnimation (Element.Water, new Vector2 (X + 147, Y + 58), SpriteEffects.FlipHorizontally));
            Add (new WalkingDjinniAnimation (Element.Fire, new Vector2 (X + 180, Y + 58), SpriteEffects.FlipHorizontally));
            Add (new WalkingDjinniAnimation (Element.Wind, new Vector2 (X + 211, Y + 58), SpriteEffects.FlipHorizontally));

            OnEvent (this.selectedCharacter);
        }

        public override void OnEvent (IObservable source)
        {
            base.OnEvent (source);

            // Update character info
            Character character = selectedCharacter.Value;
            if (character == null)
                return;

            earthDjinn.Number = 0;

            earthDjinn.Number = character.Djinn.Count (d => d.Element == Element.Earth);
            waterDjinn.Number = character.Djinn.Count (d => d.Element == Element.Water);
            fireDjinn.Number = character.Djinn.Count (d => d.Element == Element.Fire);
            windDjinn.Number = character.Djinn.Count (d => d.Element == Element.Wind);
        }
    }
}

