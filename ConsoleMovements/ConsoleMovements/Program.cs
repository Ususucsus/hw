using System;

namespace ConsoleMovements
{
    public class Program
    {
        public static void Main()
        {
            var eventLoop = new EventLoop();
            var game = new Game(eventLoop);

            eventLoop.UnknownKeyPressedHandler += game.UnknownKeyPressed;
            eventLoop.LeftHandler += game.MoveLeft;
            eventLoop.RightHandler += game.MoveRight;
            eventLoop.DownHandler += game.MoveDown;
            eventLoop.UpHandler += game.MoveUp;

            eventLoop.Run();
        }
    }
}
