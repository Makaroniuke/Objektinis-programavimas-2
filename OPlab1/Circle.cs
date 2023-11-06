using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPlab1
{
    /// <summary>
    /// Circle object
    /// </summary>
    public class Circle
    {
        public int Radius { get; private set; }
        public int Diameter { get; private set; }
        public Point CenterPoint { get; private set; }

        /// <summary>
        /// Constructor of circle
        /// </summary>
        /// <param name="radius">circle's radius</param>
        public Circle(int radius)
        {
            this.Radius = radius;
            this.Diameter = 2 * radius;
            this.CenterPoint = new Point(radius, radius);
        }

        /// <summary>
        /// Overrides ToString, to create formated line
        /// </summary>
        /// <returns>formated line</returns>
        public override string ToString()
        {
            return String.Format("Radius: {0}, center point: {1}", Radius, CenterPoint);
        }
    }
}