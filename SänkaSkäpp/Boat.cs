using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SänkaSkäpp
{
    class Boat
    {
        public int size;
        public Texture2D texture;
        public int dir;
        public Vector2 pos;
        public Rectangle rect;
        public Vector2 origin;

        public Boat(int size, Texture2D texture, int dir, Vector2 pos)
        {
            this.size = size;
            this.texture = texture;
            this.dir = dir;
            this.pos = pos;
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
            rect = new Rectangle((int)pos.X, (int)pos.Y, 50 * size, 50);

        }

    }
}
