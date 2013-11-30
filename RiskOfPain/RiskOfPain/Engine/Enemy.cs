using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RiskOfPain.Engine
{
    class Enemy : Entity
    {
        public Enemy()
        {
            Width = 32;
            Height = 32;

            Origin = new Vector2(Width / 2, Height / 2);

            Color = Color.BlueViolet;
        }
    }
}
