using System;
using OpenGoldenSunWindows.Characters;
using Microsoft.Xna.Framework;

namespace OpenGoldenSunWindows.Gui
{
    public class CharacterHpPpPane : GuiItemCollection
    {
        public Character Character { get; set; }
        public Vector2 Position { get; set; }

        private TextLabel characterName;
        private ValueBar hpBar;
        private ValueBar ppBar;

        public CharacterHpPpPane (Vector2 position)
        {
            this.Position = position;
            Add (characterName = new TextLabel (position));
            Add (hpBar = new ValueBar (new Vector2 (position.X, position.Y + 8), 40, 3));
            Add (ppBar = new ValueBar (new Vector2 (position.X, position.Y + 16), 40, 3));

            this.hpBar.Text = "HP";
            this.ppBar.Text = "PP";
        }

        public override void Update (GameTime gameTime)
        {
            this.characterName.Text = this.Character?.Name;
            this.hpBar.Value = this.Character == null ? 0 : this.Character.HP;
            this.hpBar.MaxValue = this.Character == null ? 0 : this.Character.MaxHP;
            this.ppBar.Value = this.Character == null ? 0 : this.Character.PP;
            this.ppBar.MaxValue = this.Character == null ? 0 : this.Character.MaxPP;

            base.Update (gameTime);
        }
    }
}

