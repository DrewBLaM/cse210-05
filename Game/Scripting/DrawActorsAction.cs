using System.Collections.Generic;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Player player = (Player)cast.GetFirstActor("player");
            List<Actor> segments = player.GetSegments();
            Player_2 player_2 = (Player_2)cast.GetFirstActor("player_2");
            List<Actor> segments_2 = player_2.GetSegments();
            Actor score = cast.GetFirstActor("score");
            Actor score_2 = cast.GetFirstActor("score_2");
            ///Actor food = cast.GetFirstActor("food");
            List<Actor> messages = cast.GetActors("messages");
            
            videoService.ClearBuffer();
            videoService.DrawActors(segments);
            videoService.DrawActors(segments_2);
            videoService.DrawActor(score);
            videoService.DrawActor(score_2);
            ///videoService.DrawActor(food);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}