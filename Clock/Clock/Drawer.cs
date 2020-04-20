// <copyright file="Drawer.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace Clock
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    /// <summary>
    /// Represent class for drawing clocks.
    /// </summary>
    public class Drawer
    {
        /// <summary>
        /// Current graphics object.
        /// </summary>
        private Graphics graphics;

        /// <summary>
        /// Inside form width.
        /// </summary>
        private int width;

        /// <summary>
        /// Inside form height.
        /// </summary>
        private int height;

        /// <summary>
        /// Draws clock(ellipse, serifs and numbers).
        /// </summary>
        /// <param name="graphics">Graphics object.</param>
        /// <param name="width">Inside form width.</param>
        /// <param name="height">Inside form height.</param>
        public void DrawClock(Graphics graphics, int width, int height)
        {
            this.graphics = graphics;
            this.width = width;
            this.height = height;

            this.DrawCircle();
            this.DrawSerifs();
            this.DrawNumbers();
        }

        /// <summary>
        /// Draws clock hands.
        /// </summary>
        /// <param name="clockHands">List of clock hands.</param>
        public void DrawHands(List<ClockHand> clockHands)
        {
            foreach (var clockHand in clockHands)
            {
                var (coordinate1, coordinate2) = this.GetHandCoordinates(clockHand.Angle, clockHand.LengthRatio);

                using (var pen = new Pen(Color.Black, clockHand.Width))
                {
                    this.graphics.DrawLine(pen, coordinate1, coordinate2);
                }
            }
        }

        /// <summary>
        /// Draws clock's ellipse.
        /// </summary>
        private void DrawCircle()
        {
            var circleTop = 0.1f * this.height;
            var circleLeft = 0.1f * this.width;
            var circleHeight = 0.8f * this.height;
            var circleWidth = 0.8f * this.width;

            using (var pen = new Pen(Color.Black, 3))
            {
                this.graphics.DrawEllipse(pen, circleLeft, circleTop, circleWidth, circleHeight);
            }

            using (var brush = new SolidBrush(Color.Black))
            {
                this.graphics.FillEllipse(brush, (float)(circleLeft + (circleWidth / 2) - 5), (float)(circleTop + (circleHeight / 2) - 5), 10f, 10f);
            }
        }

        /// <summary>
        /// Draws clock's serifs.
        /// </summary>
        private void DrawSerifs()
        {
            for (var i = 0; i < 12; ++i)
            {
                var (coordinate1, coordinate2) = this.GetSerifCoordinates(i);

                using (var pen = new Pen(Color.Black, 2))
                {
                    this.graphics.DrawLine(pen, coordinate1, coordinate2);
                }
            }
        }

        /// <summary>
        /// Draw clock's numbers.
        /// </summary>
        private void DrawNumbers()
        {
            for (var i = 0; i < 12; ++i)
            {
                var size = this.GetNumberSize();
                var coordinate = this.GetNumberCoordinate(i, size);

                using (var brush = new SolidBrush(Color.Black))
                {
                    this.graphics.DrawString(i.ToString(), new Font(FontFamily.GenericSansSerif, size), brush, coordinate);
                }
            }
        }

        /// <summary>
        /// Returns number coordinates. Considers size of text.
        /// </summary>
        /// <param name="index">Number index.</param>
        /// <param name="size">Type size.</param>
        /// <returns>Point with coordinates.</returns>
        private PointF GetNumberCoordinate(int index, int size)
        {
            var angle = index * 30.0;
            angle = Math.PI / 180 * angle;

            var circleTop = 0.1f * this.height;
            var circleLeft = 0.1f * this.width;
            var heightRadius = 0.4f * this.height;
            var widthRadius = 0.4f * this.width;

            var h = heightRadius * Math.Cos(angle);
            var w = widthRadius * Math.Sin(angle);

            var x = circleLeft + widthRadius + (0.95 * w);
            var y = circleTop + heightRadius - (0.95 * h);

            x -= (0.5 * size) + (Math.Sin(angle) * size);
            y -= Math.Sin(angle / 2) * size;

            if (index >= 3 && index <= 9)
            {
                y -= Math.Abs(Math.Cos(angle)) * size * 0.5;
            }

            return new PointF((float)x, (float)y);
        }

        /// <summary>
        /// Returns type size.
        /// </summary>
        /// <returns>Type size.</returns>
        private int GetNumberSize()
        {
            var heightRadius = 0.4f * this.height;
            var widthRadius = 0.4f * this.width;
            var size = (int)(0.1 * Math.Min(widthRadius, heightRadius) * 0.75);

            return size;
        }

        /// <summary>
        /// Returns coordinates for serif.
        /// </summary>
        /// <param name="index">Number index where serif is.</param>
        /// <returns>Tuple of two points with start and end coordinates.</returns>
        private (PointF, PointF) GetSerifCoordinates(int index)
        {
            var circleTop = 0.1f * this.height;
            var circleLeft = 0.1f * this.width;
            var heightRadius = 0.4f * this.height;
            var widthRadius = 0.4f * this.width;

            var angle = index * 30.0;
            angle = 2.0 * Math.PI / 360 * angle;

            var h = heightRadius * Math.Cos(angle);
            var w = widthRadius * Math.Sin(angle);

            var x1 = circleLeft + widthRadius + w;
            var x2 = circleLeft + widthRadius + (0.97 * w);
            var y1 = circleTop + heightRadius - h;
            var y2 = circleTop + heightRadius - (0.97 * h);

            return (new PointF((float)x1, (float)y1), new PointF((float)x2, (float)y2));
        }

        /// <summary>
        /// Returns coordinates for hand.
        /// </summary>
        /// <param name="angle">Hand angle.</param>
        /// <param name="lengthRatio">Angle length ratio relative with ellipse size.</param>
        /// <returns>Tuple of two points with start and end coordinates.</returns>
        private (PointF, PointF) GetHandCoordinates(double angle, double lengthRatio)
        {
            var circleTop = 0.1f * this.height;
            var circleLeft = 0.1f * this.width;
            var heightRadius = 0.4f * this.height;
            var widthRadius = 0.4f * this.width;

            var h = heightRadius * Math.Cos(angle);
            var w = widthRadius * Math.Sin(angle);

            w *= lengthRatio;
            h *= lengthRatio;

            var centerX = circleLeft + widthRadius;
            var centerY = circleTop + heightRadius;
            var x = centerX + w;
            var y = centerY - h;

            return (new PointF((float)centerX, (float)centerY), new PointF((float)x, (float)y));
        }
    }
}