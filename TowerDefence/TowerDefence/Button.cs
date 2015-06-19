using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefense
{
    class Button
    {
        private Texture2D texture; //hoe de button er uit ziet
        private Vector2 position; // de positie van de button
        private Rectangle rectangle; // de afmeting en positie van de button

        private Color color = new Color(255, 255, 255, 255); //de kleur van de button wanneer je hovert
        private Vector2 size; // de afmeting van de button
        private bool hover; //is de muis op de button
        public bool isClicked; // is de button geclicked

        public Button(Texture2D newTexture, GraphicsDevice graphics)
        {
            texture = newTexture;
            size = new Vector2(texture.Width, texture.Height);
        }

        public void Update(MouseState mouse)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

            //laat de button knipperen
            if (mouseRectangle.Intersects(rectangle))
            {
                if (color.A == 255) hover = false;
                if (color.A == 0) hover = true;
                if (hover) color.A += 3; else color.A -= 3;
                if (mouse.LeftButton == ButtonState.Pressed) isClicked = true;
            }
            else if (color.A < 255)
            {
                color.A += 3;
                isClicked = false;
            }
        }

        //de positie van de button setten
        public void setPosition(Vector2 newPosition)
        {
            position = newPosition;
        }

        //de button tekenen
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, rectangle, color);
        }
    }
}
