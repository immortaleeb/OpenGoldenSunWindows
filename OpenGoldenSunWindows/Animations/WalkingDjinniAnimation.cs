using System;
using OpenGoldenSunWindows.Characters;
using OpenGoldenSunWindows.Utils;
using Microsoft.Xna.Framework.Content;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OpenGoldenSunWindows.Animations
{
    public class WalkingDjinniAnimation : AnimatedTextureAnimation
    {
        private static AnimatedTexture[] djinnTextures;

        public Element Element { get; }
        public override AnimatedTexture Texture { 
            get { return djinnTextures [this.Element.Index]; }
        }

        private SpriteEffects spriteEffects;

        public WalkingDjinniAnimation (Element element, Vector2 position, SpriteEffects spriteEffects) : base (position)
        {
            this.Element = element;
            this.Position = position;
            this.spriteEffects = spriteEffects;
        }

        private void LoadDjinniTexture (ContentManager content, Element element, float[] frameTimes)
        {
            djinnTextures [element.Index] = new AnimatedTexture ();
            djinnTextures [element.Index].Load(content, "Sprites/Djinn/" + element.Name + "_Djinn", frameTimes.Length, frameTimes);
        }

        public override void Load (ContentManager content)
        {
            if (djinnTextures == null) {
                djinnTextures = new AnimatedTexture[Element.All.Length];

                LoadDjinniTexture (content, Element.Earth, Enumerable.Repeat (0.5f, 4).ToArray ());
                LoadDjinniTexture (content, Element.Fire, Enumerable.Repeat (0.5f, 4).ToArray ());
                LoadDjinniTexture (content, Element.Wind, Enumerable.Repeat (0.5f, 3).ToArray ());
                LoadDjinniTexture (content, Element.Water, Enumerable.Repeat (0.5f, 3).ToArray ());
            }
        }

        public override void Draw (SpriteBatch spriteBatch, GameTime gameTime)
        {
            Texture.Draw(spriteBatch, Position, null, 0, null, this.spriteEffects);
        }
    }
}

