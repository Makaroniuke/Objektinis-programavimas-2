using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPlab1
{
    /// <summary>
    /// Point object with coordinates
    /// </summary>
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }

        /// <summary>
        /// Constructor for point object
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Overrides ToString, to create formated line
        /// </summary>
        /// <returns>formated line</returns>
        public override string ToString()
        {
            return String.Format("[{0},{1}]", x, y);
        }
    }
}