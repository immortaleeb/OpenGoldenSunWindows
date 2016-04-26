using System;
using OpenGoldenSunWindows.Utils;
using OpenGoldenSunWindows.Characters;
using Microsoft.Xna.Framework;

namespace OpenGoldenSunWindows.Gui
{
    public class DjinnList : GuiItemCollection, IObserver
    {
        private ObservableList<Djinni> djinnList;
        public ObservableList<Djinni> List { 
            get { return this.djinnList; }
            set {
                this.djinnList?.UnRegister (this);
                this.djinnList = value;
                this.djinnList?.Register (this);
                this.OnEvent (this.djinnList);
            }
        }

        private DjinniLabel[] djinnLabels;

        public Vector2 Position { get; }

        public DjinnList (Vector2 position, int maxSize)
        {
            this.Position = position;

            this.GenerateDjinnLabels (maxSize);
        }

        private void GenerateDjinnLabels (int maxSize)
        {
            djinnLabels = new DjinniLabel[maxSize];
            for (int i = 0; i < djinnLabels.Length; i++) {
                Add (djinnLabels [i] = new DjinniLabel (new Vector2 (Position.X, Position.Y + 8 * i)));
            }
        }

        public void OnEvent(IObservable source)
        {
            for (int i = 0; i < List.Count; i++) {
                djinnLabels [i].Djinni = List [i];
            }
        }

        public override void Draw (Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (int i = 0; i < List.Count; i++) {
                djinnLabels [i].Draw (spriteBatch, gameTime);
            }
        }
    }
}

