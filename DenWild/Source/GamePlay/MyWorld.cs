using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DenWild.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace DenWild.Source.GamePlay
{
    public class MyWorld
    {
        public Entity hero;
        public Entity[] heroes;

        public MyWorld()
        {
            heroes = new Entity[3];
            for(int i = 0; i < heroes.Length; i++)
            {
                heroes[i] = new Entity("2d\\Marine", new Vector2(300 * (i + 1), 300), new Vector2(60, 60),
                    new List<Vector2>(), new List<Vector2>());
            }
        }

        public virtual void Update()
        {
            for (int i = 0; i < heroes.Length; i++)
            {
                heroes[i].Update();
            }
        }
        

        public virtual void Draw()
        {
            for (int i = 0; i < heroes.Length; i++)
            {
                heroes[i].Draw();
            }
        }
    }
}
