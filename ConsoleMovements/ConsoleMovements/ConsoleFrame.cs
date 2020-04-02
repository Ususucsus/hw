namespace ConsoleMovements
{
    using System;

    /// <summary>
    /// Provides methods for display game.
    /// </summary>
    public class ConsoleFrame
    {
        /// <summary>
        /// Console width in symbols.
        /// </summary>
        public const int ConsoleWidth = 80;

        /// <summary>
        /// Console height in symbols.
        /// </summary>
        public const int ConsoleHeight = 21;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleFrame"/> class.
        /// </summary>
        public ConsoleFrame()
        {
            Console.SetWindowSize(ConsoleWidth, ConsoleHeight);
            Console.Title = "Console movements";
            Console.CursorVisible = false;
            this.ShowText(string.Empty);
        }

        /// <summary>
        /// Show text on the last line.
        /// </summary>
        /// <param name="text">String which will be showed</param>
        /// <exception cref="ArgumentException">Text too long. Maximum length is 78</exception>
        public void ShowText(string text)
        {
            Console.SetCursorPosition(0, ConsoleHeight - 1);

            if (text.Length > ConsoleWidth - 2)
                throw new ArgumentException($"Text too long, max length is {ConsoleWidth - 2}.");

            Console.Write("                                                                                ");
            Console.SetCursorPosition(0, ConsoleHeight - 1);
            Console.Write($": {text}");
        }

        /// <summary>
        /// Show symbol on specified position.
        /// </summary>
        /// <param name="symbol">Symbol which will be showed</param>
        /// <param name="row">Row numbered from top to bottom starting at 0</param>
        /// <param name="column">Column numbered from left to right starting at 0</param>
        public void ShowSymbol(char symbol, int row, int column)
        {
            Console.SetCursorPosition(column, row);
            Console.Write(symbol);
        }

        /// <summary>
        /// Show string starting from specified position.
        /// </summary>
        /// <param name="str">String which will be showed</param>
        /// <param name="row">Row numbered from top to bottom starting at 0</param>
        /// <param name="column">Column numbered from left to right starting at 0</param>
        public void ShowString(string str, int row, int column)
        {
            Console.SetCursorPosition(column, row);
            Console.Write(str);
        }
    }
}