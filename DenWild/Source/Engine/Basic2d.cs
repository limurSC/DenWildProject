using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DenWild.Source.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace DenWild
{
    public class Basic2d
    {
        public Vector2 position, dims;
        public Texture2D myModel;
        public string path;
        public Basic2d(string path, Vector2 position, Vector2 dims)
        {
            this.position = position;
            this.dims = dims;
            this.path = path;

            myModel = Globals.content.Load<Texture2D>(path);
        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {
            if (myModel != null)
                Globals.spriteBatch.Draw(myModel,
                    new Rectangle((int)position.X, (int)position.Y, (int)dims.X, (int)dims.Y), null, Color.White, 0.0f,
                    new Vector2(myModel.Bounds.Width / 2, myModel.Bounds.Height / 2), new SpriteEffects(), 0);
        }
    }
}
