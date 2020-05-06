// <copyright file="SecondHand.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace Clock
{
    using System;

    /// <summary>
    /// Represents class for second hand.
    /// </summary>
    public class SecondHand : ClockHand
    {
        /// <summary>
        /// Second hand width.
        /// </summary>
        /// <value>Hand width.</value>
        public override int Width => 1;

        /// <summary>
        /// Second hand length ratio.
        /// </summary>
        /// <value>Length ratio.</value>
        public override double LengthRatio => 0.8;

        /// <summary>
        /// Second hand number of sectors.
        /// </summary>
        /// <value>Number of sectors.</value>
        protected override int NumberOfSectors => 60;

        /// <summary>
        /// Second hand sector angle.
        /// </summary>
        /// <returns>Sector angle.</returns>
        protected override double GetSectorAngle() => Math.PI / 30;

        /// <summary>
        /// Returns seconds of current time.
        /// </summary>
        /// <returns>Seconds of current time.</returns>
        protected override int GetTime() => DateTime.Now.Second;
    }
}
