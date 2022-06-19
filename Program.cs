using Unit05.Game.Casting;
using Unit05.Game.Directing;
using Unit05.Game.Scripting;
using Unit05.Game.Services;


namespace Unit05
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // Prepare the actors
            Score score_1 = new Score();
            score_1.SetPosition(new Point(0, 0));
            score_1.SetTrackedPlayer("One");
            score_1.AddPoints(0);
            Score score_2 = new Score();
            score_2.SetPosition(new Point(750, 0));
            score_2.SetTrackedPlayer("Two");
            score_2.AddPoints(0);

            // create the cast
            Cast cast = new Cast();
            cast.AddActor("food", new Food());
            cast.AddActor("player", new Player());
            cast.AddActor("player_2", new Player_2());
            cast.AddActor("score", score_1);
            cast.AddActor("score_2", score_2);

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           


            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActor1Action(keyboardService));
            script.AddAction("input", new ControlActor2Action(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}