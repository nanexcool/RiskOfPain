using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RiskOfPain.Engine
{
    class SceneManager
    {
        SpriteBatch spriteBatch;

        public List<Scene> Scenes { get; set; }

        public void Update(float elapsed)
        {
            foreach (Scene s in Scenes)
            {
                if (s.Enabled)
                {
                    s.Update(elapsed);
                }
            }
        }

        public void Draw()
        {
            foreach (Scene s in Scenes)
            {
                if (s.Visible)
                {
                    s.Draw(spriteBatch);
                }
            }
        }
    }
}
