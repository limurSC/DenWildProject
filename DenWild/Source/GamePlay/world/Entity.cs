using System;
using System.Collections.Generic;
using System.IO;
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

namespace DenWild.World
{
    public class Entity : Basic2d
    {

        private int entitySpeed = 10;
        private List<Vector2> motionVectors;
        private List<Vector2> mouseClicks;
        private Vector2 motionVector;
        private Vector2 mouseClick;

        public Entity(string path, Vector2 position, Vector2 dims, List<Vector2> motionVectors, List<Vector2> mouseClicks) 
            : base(path, position, dims)
        {
            this.motionVectors = motionVectors;
            this.mouseClicks = mouseClicks;
            motionVector = new Vector2();
        }

        public override void Update()
        {
            Moving();
            base.Update();
        }

        public void Moving() // потом исправить
        {
            var mouse = Mouse.GetState();
            var keyboard = Keyboard.GetState();
            if (mouse.RightButton == ButtonState.Pressed)
            {
                var pressedKeys = keyboard.GetPressedKeys();
                mouseClick = new Vector2(mouse.Position.X, mouse.Position.Y);
                if (motionVectors.Count > 0 && pressedKeys.Length > 0 && pressedKeys[0] == Keys.LeftShift)
                {
                    motionVector = new Vector2(mouseClick.X - mouseClicks[mouseClicks.Count - 1].X,
                        mouseClick.Y - mouseClicks[mouseClicks.Count - 1].Y);
                    var distance = motionVector.Length();
                    if(distance > 0)
                        motionVector = new Vector2(motionVector.X / distance,
                            motionVector.Y / distance) * entitySpeed;
                }
                else
                {
                    motionVector = new Vector2(mouseClick.X - position.X,
                    mouseClick.Y - position.Y);
                    var distance = motionVector.Length();
                    motionVector = new Vector2(motionVector.X / distance,
                    motionVector.Y / distance) * entitySpeed;
                }
                if (pressedKeys.Length == 0 || pressedKeys[0] != Keys.LeftShift)
                {
                    if (motionVectors.Count > 0)
                    {
                        motionVectors.Clear();
                        mouseClicks.Clear();
                    }
                    motionVectors.Add(motionVector);
                    mouseClicks.Add(mouseClick);
                }
                if (pressedKeys.Length > 0 && pressedKeys[0] == Keys.LeftShift)
                {
                    motionVectors.Add(motionVector);
                    mouseClicks.Add(mouseClick);
                }
            }
            if (mouseClicks.Count != 0 && (mouseClicks[0] - position).Length() >= entitySpeed)
            {
                position += motionVectors[0];
            }
            else if (mouseClicks.Count != 0 && (mouseClicks[0] - position).Length() < entitySpeed)
            {
                position = mouseClicks[0];
                motionVectors.RemoveAt(0);
                mouseClicks.RemoveAt(0);
            }
        }


        public override void Draw()
        {
            base.Draw();
        }
    }
}
