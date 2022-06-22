using System;


namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>A class that tracks player scores.</para>
    /// <para>
    /// The responsibility of Score is to assign an int value to a tracked player, store that value, and add points to the value
    /// </para>
    /// </summary>
    public class Score : Actor
    {
        private int points = 0;
        private string trackedPlayer = "";
        /// <summary>
        /// Constructs a new instance of Score.
        /// </summary>
        public Score()
        {
            AddPoints(0);
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddPoints(int points)
        {
            this.points += points;
            SetText($"Player {trackedPlayer}: {this.points}");
        }
       
        /// <summary>
        /// Assign an instance of score to a player
        /// </summary>
        public void SetTrackedPlayer(string trackedPlayer)
        {
            this.trackedPlayer = trackedPlayer;
        }
    }
}