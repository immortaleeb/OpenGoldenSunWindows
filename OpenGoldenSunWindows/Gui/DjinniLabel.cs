using System;
using OpenGoldenSunWindows.Characters;
using Microsoft.Xna.Framework;
using OpenGoldenSunWindows.Utils;

namespace OpenGoldenSunWindows.Gui
{
    public class DjinniLabel : GuiItemCollection
    {
        private Djinni djinni;
        public Djinni Djinni { 
            get { return djinni; }
            set {
                if (value != djinni) {
                    djinni = value;
                    DjinniChanged ();
                }
            }
        }

        public Vector2 Position;

        private IconLabel elementLabel;
        private TextLabel nameLabel;

        public DjinniLabel (Vector2 position)
        {
            this.Position = position;

            Add (elementLabel = new IconLabel (Icons.Venus, new Vector2 (position.X, position.Y + 1)));
            Add (nameLabel = new TextLabel (new Vector2 (position.X + 7, position.Y)));
        }

        private void DjinniChanged ()
        {
            if (djinni == null)
                return;

            Console.WriteLine (elementLabel.IsVisible);
            elementLabel.Icon = GlobalReference.GetElementIcon (djinni.Element);
            nameLabel.Text = djinni.Name;
        }

        public override void SetVisible (bool visible)
        {
            Console.WriteLine ("SetVisible {0} {1}", djinni?.Name, visible);
            base.SetVisible (visible);
        }

        public override void Draw (Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, GameTime gameTime)
        {
            Console.WriteLine ("Draw {0}", djinni?.Name);
            base.Draw (spriteBatch, gameTime);
        }
    }
}

