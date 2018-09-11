using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SänkaSkäpp
{
    class GameMap
    {

        Texture2D tex;
        public GameMap(GraphicsDevice gd)
        {
            tex = new Texture2D(gd, 1, 1);
            tex.SetData<Color>(new Color[] { Color.White });
        }

        public void DrawLines(SpriteBatch sb, Color lineColor)
        {
            for (int i = 0; i < 11; i++)
            {
                sb.Draw(tex, new Rectangle(0, i * 50, 500, 2), lineColor);
                sb.Draw(tex, new Rectangle(i * 50, 0, 2, 500), lineColor);
            }
        }

    }
}
