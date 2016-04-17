using System;
using Microsoft.Xna.Framework;
using OpenGoldenSunWindows.Utils;
using Microsoft.Xna.Framework.Graphics;

namespace OpenGoldenSunWindows.Gui
{
    public enum Icons
    {
        Psynergy = 0,
        Djinn,
        Item,
        Status,
        Cursor,
        LButton,
        RButton,
        AButton,

        Venus,
        Mercury,
        Mars,
        Jupiter
    }

    public class IconLabel : TextureLabel
    {
        private static Texture2D[] iconTextures;

        public static Texture2D GetIconTexture(Icons icon)
        {
            return iconTextures [(int)icon];
        }

        public Icons Icon { get; }
        public override Texture2D Texture { get { return GetIconTexture (this.Icon); } }

        public IconLabel (Icons icon, Vector2 position) : base (position)
        {
            this.Icon = icon;
        }

        public override void Load (Microsoft.Xna.Framework.Content.ContentManager content)
        {
            if (iconTextures == null) {
                string[] icons = Enum.GetNames (typeof(Icons));
                iconTextures = new Texture2D[icons.Length];

                for (int i = 0; i < icons.Length; i++) {
                    iconTextures [i] = content.Load<Texture2D> ("Sprites/Icons/" + icons [i]);
                }
            }
        }
    }
}

