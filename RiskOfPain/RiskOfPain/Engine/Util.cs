using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RiskOfPain.Engine
{
    static class Util
    {
        public static Texture2D Texture { get; set; }
        public static Viewport Viewport { get; set; }

        static Random random = new Random();

        public static void Initialize(Game game)
        {
            Texture = new Texture2D(game.GraphicsDevice, 1, 1);
            Texture.SetData<Color>(new Color[] { Color.White });

            Viewport = game.GraphicsDevice.Viewport;
        }

        public static double NextDouble()
        {
            return random.NextDouble();
        }

        public static float NextFloat()
        {
            return (float)random.NextDouble();
        }

        public static int Next()
        {
            return random.Next();
        }

        public static int Next(int max)
        {
            return random.Next(max);
        }

        public static int Next(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
