using System;
using Microsoft.Xna.Framework;
using OpenGoldenSunWindows.Utils;

namespace OpenGoldenSunWindows.Gui
{
    public class ValueBar : GuiItemCollection
    {
        private static Color positiveColor = Color.Blue;
        private static Color negativeColor = Color.Red;

        public Vector2 Position { get; }
        public string Text { get; set; }
        public int Value { get; set; }
        public int MaxValue { get; set; }

        private TextLabel textLabel;
        private IntegerLabel statLabel;

        private int width;
        private int height;

        private Rectangle positiveBounds;
        private Rectangle negativeBounds;

        public ValueBar (Vector2 position, int width, int height)
        {
            this.Position = position;
            this.width = width;
            this.height = height;

            positiveBounds = new Rectangle ((int)this.Position.X, (int)this.Position.Y + 5, this.width, this.height);
            negativeBounds = new Rectangle ((int)this.Position.X, (int)this.Position.Y + 5, 0, this.height);

            Add (textLabel = new TextLabel (new Vector2 (Position.X, Position.Y)));
            Add (statLabel = new IntegerLabel (new Vector2 (Position.X + width - 4, Position.Y)));
        }

        public override void Update (GameTime gameTime)
        {
            base.Update (gameTime);

            this.textLabel.Text = this.Text;
            this.statLabel.Number = this.Value;

            float positiveRatio = this.MaxValue == 0 ? 0f : (float)this.Value / this.MaxValue;
            positiveBounds.Width = (int)(positiveRatio * this.width + 0.5f);
            negativeBounds.X = (int)this.Position.X + positiveBounds.Width;
            negativeBounds.Width = this.width - positiveBounds.Width;
        }

        public override void Draw (Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, GameTime gameTime)
        {
            GraphicsHelper.Clear (spriteBatch, positiveBounds, positiveColor);
            GraphicsHelper.Clear (spriteBatch, negativeBounds, negativeColor);

            base.Draw (spriteBatch, gameTime);
        }
    }
}

