using System;
using System.Collections.Generic;
using System.Data;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the player 
    /// collides with the food, or the player collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Sets the game over flag if the player collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Player player = (Player)cast.GetFirstActor("player");
            Actor head = player.GetHead();
            List<Actor> body = player.GetBody();
            Player_2 player_2 = (Player_2)cast.GetFirstActor("player_2");
            Actor head_2 = player_2.GetHead();
            List<Actor> body_2 = player_2.GetBody();

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    isGameOver = true;
                }
            }

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head_2.GetPosition()))
                {
                    isGameOver = true;
                }
            }

            foreach (Actor segment in body_2)
            {
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    isGameOver = true;
                }
            }

            foreach (Actor segment in body_2)
            {
                if (segment.GetPosition().Equals(head_2.GetPosition()))
                {
                    isGameOver = true;
                }
            }
        }

        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                Player player = (Player)cast.GetFirstActor("player");
                List<Actor> segments = player.GetSegments();
                Player_2 player_2 = (Player_2)cast.GetFirstActor("player_2");
                List<Actor> segments_2 = player_2.GetSegments();

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                foreach (Actor segment in segments)
                {
                    segment.SetColor(Constants.WHITE);
                }

                foreach (Actor segment in segments_2)
                {
                    segment.SetColor(Constants.WHITE);
                }
            }
        }

        public bool getIsGameOver()
        {
            return this.isGameOver;
        }

    }
}