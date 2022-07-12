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
        public Player(Body body, bool debug) : base(debug)
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

        /// <summary>
        /// Swings the racket to the left.
        /// </summary>
        public void SwingLeft()
        {
            Point velocity = new Point(-Constants.PLAYER_VELOCITY, 0);
            body.SetVelocity(velocity);
        }

        /// <summary>
        /// Swings the racket to the right.
        /// </summary>
        public void SwingRight()
        {
            Point velocity = new Point(Constants.PLAYER_VELOCITY, 0);
            body.SetVelocity(velocity);
        }

        /// <summary>
        /// Swings the racket to the right.
        /// </summary>
        public void SwingRight()
        {
            Point velocity = new Point(Constants.PLAYER_VELOCITY, 0);
            body.SetVelocity(velocity);
        }

        /// <summary>
        /// Stops the racket from moving.
        /// </summary>
        public void StopMoving()
        {
            Point velocity = new Point(0, 0);
            body.SetVelocity(velocity);
        }
        
    }
}