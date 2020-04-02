using System.ComponentModel.Design;
using System.IO;

namespace ConsoleMovements
{
    using System;

    /// <summary>
    /// Represents class with game logic.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Console frame for render.
        /// </summary>
        private readonly ConsoleFrame consoleFrame;

        /// <summary>
        /// Game map.
        /// </summary>
        private readonly Map map;

        /// <summary>
        /// Game event loop.
        /// </summary>
        private readonly EventLoop eventLoop;

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// <param name="eventLoop">Event loop</param>
        /// </summary>
        public Game(EventLoop eventLoop)
        {
            this.consoleFrame = new ConsoleFrame();
            this.eventLoop = eventLoop;
            try
            {
                this.map = new Map();
            }
            catch (InvalidSaveFileException)
            {
                this.consoleFrame.ShowText("Invalid save file");
                this.eventLoop.IsGameActive = false;
            }
            catch (FileNotFoundException)
            {
                this.consoleFrame.ShowText("Save file not found");
                this.eventLoop.IsGameActive = false;
            }

            if (map == null)
                return;

            this.consoleFrame.ShowString(map.ToString(), 0, 0);
        }

        /// <summary>
        /// Unknown key pressed handler. Shows string with error message on last line.
        /// </summary>
        /// <param name="sender">sender of event</param>
        /// <param name="args">args of event</param>
        public void UnknownKeyPressed(object? sender, EventArgs args)
        {
            this.consoleFrame.ShowText("Unknown keyboard button");
        }

        /// <summary>
        /// Step left.
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="args">event arguments</param>
        public void MoveLeft(object? sender, EventArgs args)
        {
            if (map.HeroColumn != 0 && map[map.HeroRow, map.HeroColumn - 1] == '.')
            {
                map[map.HeroRow, map.HeroColumn] = '.';
                map[map.HeroRow, map.HeroColumn - 1] = '@';
                --map.HeroColumn;
                this.consoleFrame.ShowString(map.ToString(), 0, 0);
                this.consoleFrame.ShowText(string.Empty);
            }
            else
            {
                this.consoleFrame.ShowText("Can't move!");
            }
        }

        /// <summary>
        /// Step right.
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="args">event arguments</param>
        public void MoveRight(object? sender, EventArgs args)
        {
            if (map.HeroColumn != map.Width - 1 && map[map.HeroRow, map.HeroColumn + 1] == '.')
            {
                map[map.HeroRow, map.HeroColumn] = '.';
                map[map.HeroRow, map.HeroColumn + 1] = '@';
                ++map.HeroColumn;
                this.consoleFrame.ShowString(map.ToString(), 0, 0);
                this.consoleFrame.ShowText(string.Empty);
            }
            else
            {
                this.consoleFrame.ShowText("Can't move!");
            }
        }

        /// <summary>
        /// Step up.
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="args">event arguments</param>
        public void MoveUp(object? sender, EventArgs args)
        {
            if (map.HeroRow != 0 && map[map.HeroRow - 1, map.HeroColumn] == '.')
            {
                map[map.HeroRow, map.HeroColumn] = '.';
                map[map.HeroRow - 1, map.HeroColumn] = '@';
                --map.HeroRow;
                this.consoleFrame.ShowString(map.ToString(), 0, 0);
                this.consoleFrame.ShowText(string.Empty);
            }
            else
            {
                this.consoleFrame.ShowText("Can't move!");
            }
        }

        /// <summary>
        /// Step down.
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="args">event arguments</param>
        public void MoveDown(object? sender, EventArgs args)
        {
            if (map.HeroRow != map.Height - 1 && map[map.HeroRow + 1, map.HeroColumn] == '.')
            {
                map[map.HeroRow, map.HeroColumn] = '.';
                map[map.HeroRow + 1, map.HeroColumn] = '@';
                ++map.HeroRow;
                this.consoleFrame.ShowString(map.ToString(), 0, 0);
                this.consoleFrame.ShowText(string.Empty);
            }
            else
            {
                this.consoleFrame.ShowText("Can't move!");
            }
        }
    }
}