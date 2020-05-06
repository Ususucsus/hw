// <copyright file="MinuteHand.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace Clock
{
    using System;

    /// <summary>
    /// Represents class for minute hand.
    /// </summary>
    public class MinuteHand : ClockHand
    {
        /// <summary>
        /// Minute hand width.
        /// </summary>
        /// <value>Hand width.</value>
        public override int Width => 2;

        /// <summary>
        /// Minute hand length ratio.
        /// </summary>
        /// <value>Length ratio.</value>
        public override double LengthRatio => 0.6;

        /// <summary>
        /// Minute hand number of sectors.
        /// </summary>
        /// <value>Number of sectors.</value>
        protected override int NumberOfSectors => 3600;

        /// <summary>
        /// Minute hand sector angle.
        /// </summary>
        /// <returns>Sector angle.</returns>
        protected override double GetSectorAngle() => Math.PI / 1800;

        /// <summary>
        /// Returns minutes and seconds of current time in seconds.
        /// </summary>
        /// <returns>Minute and seconds.</returns>
        protected override int GetTime() => (DateTime.Now.Minute * 60) + DateTime.Now.Second;
    }
}