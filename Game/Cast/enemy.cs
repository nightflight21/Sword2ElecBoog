using System;
using System.Collections.Generic;


namespace Sword.Casting
{
    /// <summary>
    /// 
    /// </summary>
    public class Enemy : Actor
    {
        private static Random random = new Random();

        private Body body;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Enemy(Body body, bool debug = false) : base(debug)
        {
            this.body = body;
        }

        /// <summary>
        /// Bounces the Enemy horizontally.
        /// </summary>
        public void BounceX()
        {
            Point velocity = body.GetVelocity();
            double rn = (random.NextDouble() * (1.2 - 0.8) + 0.8);
            double vx = velocity.GetX() * -1;
            double vy = velocity.GetY();
            Point newVelocity = new Point((int)vx, (int)vy);
            body.SetVelocity(newVelocity);
        }

        /// <summary>
        /// Bounces the Enemy vertically.
        /// </summary>
        public void BounceY()
        {
            Point velocity = body.GetVelocity();
            double rn = (random.NextDouble() * (1.2 - 0.8) + 0.8);
            double vx = velocity.GetX();
            double vy = velocity.GetY() * -1;
            Point newVelocity = new Point((int)vx, (int)vy);
            body.SetVelocity(newVelocity);
        }
        
        /// <summary>
        /// Gets the body.
        /// </summary>
        /// <returns>The body.</returns>
        public Body GetBody()
        {
            return body;
        }

        /// <summary>
        /// Releases Enemy in random horizontal direction.
        /// </summary>
        public void Release()
        {
            Point velocity = body.GetVelocity();
            List<int> velocities = new List<int> {Constants.ENEMY_VELOCITY, Constants.ENEMY_VELOCITY};
            int index = random.Next(velocities.Count);
            double vx = velocities[index];
            double vy = -Constants.ENEMY_VELOCITY;
            Point newVelocity = new Point((int)vx, (int)vy);
            body.SetVelocity(newVelocity);
        }
    }
}