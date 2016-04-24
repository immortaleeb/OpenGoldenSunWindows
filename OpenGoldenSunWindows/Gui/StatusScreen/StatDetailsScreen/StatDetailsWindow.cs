using System;
using System.Linq;
using OpenGoldenSunWindows.Utils;
using OpenGoldenSunWindows.Characters;
using Microsoft.Xna.Framework;
using OpenGoldenSunWindows.Animations;
using System.Collections.Generic;

namespace OpenGoldenSunWindows.Gui.StatusScreen.StatDetailsScreen
{
    public class StatDetailsWindow : StatusWindowBase
    {
        public static Rectangle[] SelectableAreas = {
            new Rectangle (8, 48, 40, 8),
            new Rectangle (48, 8, 104, 8),
            new Rectangle (48, 16, 104, 8),
            new Rectangle (48, 24, 104, 8),
            new Rectangle (48, 32, 104, 8),
            new Rectangle (72, 72, 160, 8),
            new Rectangle (72, 80, 160, 8),
            new Rectangle (72, 88, 160, 8),
            new Rectangle (72, 96, 160, 8)
        };

        private static Element[] elements = new Element[4] { 
            Element.Earth, Element.Water, Element.Fire, Element.Wind 
        };
        private static Icons[] elementIcons = new Icons[4] { 
            Icons.Venus, Icons.Mercury, Icons.Mars, Icons.Jupiter
        };

        private Rectangle selectedArea;
        private ObservableReference<int> cursorPosition;

        private CursorAnimation cursorAnimation;

        private IntegerLabel[,] djinnStats;

        public StatDetailsWindow (ObservableReference<Character> selectedCharacter, ObservableReference<int> cursorPosition, int x, int y) : base (selectedCharacter, x, y)
        {
            this.cursorPosition = cursorPosition;
            cursorPosition.Register (this);

            Add (cursorAnimation = new CursorAnimation (Vector2.Zero));
            Add (new TextLabel ("Djinn", new Vector2 (this.X + 72, this.Y + 72)));
            Add (new TextLabel ("Lv", new Vector2 (this.X + 72, this.Y + 80)));
            Add (new TextLabel ("Power", new Vector2 (this.X + 72, this.Y + 88)));
            Add (new TextLabel ("Resist", new Vector2 (this.X + 72, this.Y + 96)));

            GenerateDjinnStats ();

            UpdateSelectedRectangle ();
            OnEvent (this.selectedCharacter);
        }

        private void GenerateDjinnStats ()
        {
            djinnStats = new IntegerLabel[Element.All.Length, 5];
            for (int col = 0; col < elements.Length; col++) {
                var element = elements [col];
                var icon = elementIcons [col];

                // Separators
                Add (new TextLabel("/", new Vector2(this.X + 120 + col * 32, this.Y + 72)));

                // Djinn/element icons
                Add (new WalkingDjinniAnimation (
                    element, 
                    new Vector2 (this.X + 115 + col * 32, this.Y + 34), 
                    Microsoft.Xna.Framework.Graphics.SpriteEffects.FlipHorizontally));
                Add (new IconLabel (icon, new Vector2 (this.X + 129 + col * 32, this.Y + 65)));

                // Integer labels
                Add (djinnStats [col, 0] = new IntegerLabel (new Vector2 (this.X + 119 + col * 32, this.Y + 72)));
                for (int row = 1; row < djinnStats.GetLength (1); row++) {
                    Add (djinnStats [col, row] = new IntegerLabel (new Vector2 (
                        this.X + 136 + col * 32, 
                        this.Y + 72 + (row - 1) * 8
                    )));
                }
            }
        }

        private void UpdateSelectedRectangle()
        {   selectedArea = SelectableAreas [cursorPosition.Value + 1];

            cursorAnimation.Position = new Vector2 (Math.Max(0, this.X + selectedArea.X - 16), this.Y + selectedArea.Y + 8);
            selectedArea.Offset (new Point (this.X, this.Y));
        }

        public override void OnEvent (IObservable source)
        {
            base.OnEvent (source);

            if (source == cursorPosition) {
                UpdateSelectedRectangle ();
            } else if (source == this.selectedCharacter) {
                var character = this.selectedCharacter.Value;
                if (character == null)
                    return;

                for (int i = 0; i < elements.Length; i++) {
                    var element = elements [i];
                    IEnumerable<Djinni> djinn = character.Djinn.Where (d => d.Element == element);

                    djinnStats [i, 0].Number = djinn.Count (d => d.Status == DjinniStatus.Set);
                    djinnStats [i, 1].Number = djinn.Count();
                    djinnStats [i, 2].Number = character.ElementalLevel (element);
                    djinnStats [i, 3].Number = character.ElementalPower (element);
                    djinnStats [i, 4].Number = character.ElementalResistance (element);
                }
            }
        }

        protected override void DrawContent (Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, GameTime gameTime)
        {
            GraphicsHelper.Clear (spriteBatch, selectedArea, WindowManager.SelectionColor); 

            base.DrawContent (spriteBatch, gameTime);
        }
    }
}

