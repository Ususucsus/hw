// <copyright file="ClockHand.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace Clock
{
    /// <summary>
    /// Represents a class for clock hand. 
    /// </summary>
    public abstract class ClockHand
    {
        /// <summary>
        /// Current sector.
        /// </summary>
        private int currentSector;

        /// <summary>
        /// Time in previous tick.
        /// </summary>
        private int previousTime = -1;

        /// <summary>
        /// Gets current hand angle.
        /// </summary>
        /// <value>Current hand angle.</value>
        public double Angle => this.currentSector * this.GetSectorAngle();

        /// <summary>
        /// Gets hand width in pixels.
        /// </summary>
        /// <value>Hand width.</value>
        public abstract int Width { get; }

        /// <summary>
        /// Gets hand length ratio relatively to clock radius.
        /// </summary>
        /// <value>Length ratio.</value>
        public abstract double LengthRatio { get; }

        /// <summary>
        /// Gets total number of sectors for hand.
        /// </summary>
        /// <value>Number of sectors.</value>
        protected abstract int NumberOfSectors { get; }

        /// <summary>
        /// Update hand.
        /// </summary>
        public void Tick()
        {
            var currentTime = this.GetTime();

            if (currentTime != this.previousTime)
            {
                this.currentSector = currentTime;
                this.previousTime = currentTime;
            }
        }

        /// <summary>
        /// Returns time for hand.
        /// </summary>
        /// <returns>Time for hand.</returns>
        protected abstract int GetTime();

        /// <summary>
        /// Returns angle of one sector for hand.
        /// </summary>
        /// <returns>Angle of one sector for hand.</returns>
        protected abstract double GetSectorAngle();
    }
}
