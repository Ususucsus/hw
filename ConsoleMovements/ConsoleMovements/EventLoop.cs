namespace ConsoleMovements
{
    using System;

    /// <summary>
    /// Class provides processing cycle.
    /// </summary>
    public class EventLoop
    {
        /// <summary>
        /// Handlers for left array key pressed.
        /// </summary>
        public event EventHandler<EventArgs> LeftHandler = (sender, args) => { };

        /// <summary>
        /// Handlers for right array key pressed.
        /// </summary>
        public event EventHandler<EventArgs> RightHandler = (sender, args) => { };

        /// <summary>
        /// Handlers for up array key pressed.
        /// </summary>
        public event EventHandler<EventArgs> UpHandler = (sender, args) => { };

        /// <summary>
        /// Handlers for down array key pressed.
        /// </summary>
        public event EventHandler<EventArgs> DownHandler = (sender, args) => { };

        /// <summary>
        /// Handlers for other key pressed.
        /// </summary>
        public event EventHandler<EventArgs> UnknownKeyPressedHandler = (sender, args) => { };

        /// <summary>
        /// Event loop running while IsGameActive is true
        /// </summary>
        public bool IsGameActive { get; set; } = true;

        /// <summary>
        /// Processing cycle.
        /// </summary>
        public void Run()
        {
            while (this.IsGameActive)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        this.LeftHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.RightArrow:
                        this.RightHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.DownArrow:
                        this.DownHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.UpArrow:
                        this.UpHandler(this, EventArgs.Empty);
                        break;
                    default:
                        this.UnknownKeyPressedHandler(this, EventArgs.Empty);
                        break;
                }
            }
        }
    }
}