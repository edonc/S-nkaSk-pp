using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SänkaSkäpp
{
    class Tile
    {
        Rectangle rect;
        bool status;
        public Tile(Rectangle rectangle)
        {
            rect = rectangle;
            status = true;
        }

        public void Draw(SpriteBatch sb, Texture2D texture)
        {
            if (status)
            {
                sb.Draw(texture, rect, Color.White);
            }

        }

        public void CheckTile(int x, int y)
        {
            if (rect.Contains(x, y) && status)
                status = false;

            else if (rect.Contains(x, y) && !status)
                status = true;
        }
    }

}
