// <copyright file="ClockForm.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace Clock
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    /// <summary>
    /// Represents class for form with clock.
    /// </summary>
    public partial class ClockForm : Form
    {
        /// <summary>
        /// List of clock hands.
        /// </summary>
        private readonly List<ClockHand> clockHands;

        /// <summary>
        /// Object for drawing clock.
        /// </summary>
        private readonly Drawer drawer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClockForm"/> class.
        /// </summary>
        public ClockForm()
        {
            this.InitializeComponent();

            this.clockHands = new List<ClockHand> { new SecondHand(), new MinuteHand(), new HourHand() };

            this.drawer = new Drawer();
        }

        /// <summary>
        /// On form paint event handler. Redraws clock hands.
        /// </summary>
        /// <param name="e">Paint event arguments.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            this.drawer.DrawClock(e.Graphics, this.ClientSize.Width, this.ClientSize.Height);
            this.drawer.DrawHands(this.clockHands);
        }

        /// <summary>
        /// Timer one second tick event handler.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (var clockHand in this.clockHands)
            {
                clockHand.Tick();   
            }

            this.Refresh();
        }

        /// <summary>
        /// On form resize event handler. Refresh form.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        private void ClockForm_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

        /// <summary>
        /// Form loaded event handler. Enables one second timer.
        /// </summary>
        /// <param name="sender">Object sender.</param>
        /// <param name="e">Event arguments.</param>
        private void ClockForm_Load(object sender, EventArgs e)
        {
            this.Timer.Enabled = true;
        }
    }
}
