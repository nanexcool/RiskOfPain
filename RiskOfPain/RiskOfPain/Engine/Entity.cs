using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RiskOfPain.Engine
{
    abstract class Entity
    {
        public bool OnGround { get; set; }

        protected Vector2 position;
        protected Vector2 velocity;
        protected Vector2 acceleration;

        public int X { get { return (int)Math.Floor(position.X); } }
        public int Y { get { return (int)Math.Floor(position.Y); } }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        public Vector2 Acceleration
        {
            get { return acceleration; }
            set { acceleration = value; }
        }

        public Vector2 Origin { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public Color Color { get; set; }

        public int Health { get; set; }

        public virtual Rectangle CollisionBox
        {
            get
            {
                return new Rectangle(X, Y, Width, Height);
            }
        }

        public Entity()
        {
            Health = 5;
        }

        public virtual void OnCollide(Entity e)
        {
            return;
        }

        public void Jump()
        {
            if (OnGround)
            {
                OnGround = false;
                velocity.Y -= 400;
            }
        }

        public virtual void Update(float elapsed)
        {
            Acceleration += new Vector2(0, 2000) * elapsed;
            velocity += Acceleration * elapsed;
            velocity = Vector2.Clamp(velocity, new Vector2(-300, -1000), new Vector2(300, 1000));
            position += velocity * elapsed;

            position = Vector2.Clamp(position, Vector2.Zero + Origin, new Vector2(Util.Viewport.Width, Util.Viewport.Height) - Origin);

            if (position.Y + Origin.Y == Util.Viewport.Height)
            {
                OnGround = true;
            }
            if (OnGround)
            {
                velocity.Y = 0;
                acceleration.Y = 0;
                if (velocity.X > 0)
                {
                    velocity.X *= 0.9f;
                }
                if (velocity.X < 0)
                {
                    velocity.X *= 0.9f;
                }
                if (Math.Abs(velocity.X) < 0.1f)
                {
                    velocity.X = 0;
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Util.Texture, new Rectangle(X, Y, Width, Height), new Rectangle(0, 0, Width, Height), Color, 0, Origin, SpriteEffects.None, 0);
        }
    }
}
