// <copyright file="HourHand.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace Clock
{
    using System;

    /// <summary>
    /// Represents class for hour hand.
    /// </summary>
    public class HourHand : ClockHand
    {
        /// <summary>
        /// Hour hand width.
        /// </summary>
        /// <value>Hand width.</value>
        public override int Width => 3;

        /// <summary>
        /// Hour hand length ratio.
        /// </summary>
        /// <value>Length ratio.</value>
        public override double LengthRatio => 0.5;

        /// <summary>
        /// Hour hand number of sectors.
        /// </summary>
        /// <value>Number of sectors.</value>
        protected override int NumberOfSectors => 60;

        /// <summary>
        /// Hour hand sector angle.
        /// </summary>
        /// <returns>Sector angle.</returns>
        protected override double GetSectorAngle() => Math.PI / 360;

        /// <summary>
        /// Returns hours and minutes of current time in minutes.
        /// </summary>
        /// <returns>Hours and minutes of current time.</returns>
        protected override int GetTime() => ((DateTime.Now.Hour % 12) * 60) + DateTime.Now.Minute;
    }
}