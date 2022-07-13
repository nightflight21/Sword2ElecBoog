using System;
using System.Numerics;

namespace Sword.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class Player : Actor
    {
        private Body body;
        
        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Player(Body body)
        {
            this.body = body;
            //this.animation = animation;
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
        /// Moves the racket to its next position.
        /// </summary>
        public void MoveNext()
        {
            Point position = body.GetPosition();
            Point velocity = body.GetVelocity();
            Point newPosition = position.Add(velocity);
            body.SetPosition(newPosition);
        }

        public virtual void Steer(Vector2 vector)
        {
            //_velocity = vector;
        }
        
    }
}