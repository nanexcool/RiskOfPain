using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RiskOfPain.Engine
{
    class Player : Entity
    {
        float hurtTimer = 0;

        public Player()
        {
            Width = 32;
            Height = 48;

            Origin = new Vector2(Width / 2, Height / 2);

            Color = Color.Red;
        }

        public override void OnCollide(Entity e)
        {
            //base.OnCollide(e);
            if (e is Enemy)
            {
                velocity *= -100;
                if (hurtTimer <= 0)
                {
                    Health--;
                    hurtTimer += 1;
                }
            }
        }

        public override void Update(float elapsed)
        {
            if (hurtTimer > 0)
            {
                hurtTimer -= elapsed;
            }

            base.Update(elapsed);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
