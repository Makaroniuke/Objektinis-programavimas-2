using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPlab1
{
    /// <summary>
    /// Class for counting
    /// </summary>
    public static class TaskUtils
    {
        /// <summary>
        /// Checks if cell is inside the circle
        /// </summary>
        /// <param name="centerPoint">circle's center point</param>
        /// <param name="point">current point</param>
        /// <param name="radius">circle radius</param>
        /// <returns></returns>
        public static bool CellCoordsInsideCircle(Point centerPoint, Point point, int radius)
        {
            /// <summary>
            /// Local function to check if specific point is in circle
            /// </summary>
            /// <param name="centerPoint1">circle's center point</param>
            /// <param name="point1">current point</param>
            /// <param name="radius1">circle radius</param>
            /// <returns>true if distance is equal or less than radius, otherwise false</returns>
            bool pointIsInsideCircle(Point centerPoint1, Point point1, int radius1)
            {
                int dx = centerPoint1.x - point1.x;
                int dy = centerPoint1.y - point1.y;
                double dist = Math.Sqrt(dx * dx + dy * dy);

                return dist <= radius1 ? true : false;
            }

            bool fullSquare = false;

            List<Point> coordsToCheck = new List<Point>();
            coordsToCheck.Add(point);
            coordsToCheck.Add(new Point(point.x, point.y + 1));
            coordsToCheck.Add(new Point(point.x + 1, point.y + 1));
            coordsToCheck.Add(new Point(point.x + 1, point.y));

            int pointToCheckIdx = coordsToCheck.Count - 1;

            recursiveCellCoordsInsideCircle(centerPoint, pointToCheckIdx, radius);

            /// <summary>
            /// Local recursive method to check if all 4 cell points are in circle
            /// </summary>
            /// <param name="centerPoint2">circle's center point</param>
            /// <param name="point2">current point</param>
            /// <param name="radius2">circle radius</param>
            void recursiveCellCoordsInsideCircle(Point centerPoint2, int pointToCheckIdx2, int radius2)
            {

                if (!pointIsInsideCircle(centerPoint2, coordsToCheck[pointToCheckIdx2], radius2))
                {
                    return;
                }

                if (pointToCheckIdx2 - 1 >= 0)
                {
                    recursiveCellCoordsInsideCircle(centerPoint2, pointToCheckIdx2 - 1, radius2);
                }
                else
                {
                    fullSquare = true;                 
                }
                
            }

            return fullSquare;
        }

        /// <summary>
        /// Gets list with point which are in circle
        /// </summary>
        /// <param name="circle">created object - circle</param>
        /// <returns>list with points</returns>
        public static List<Point> GetSquaresInCircle(Circle circle)
        {
            List<Point> pointsInCircle = new List<Point>();
            for (int i = 0; i < circle.Diameter; i++)
            {
                for (int j = 0; j < circle.Diameter; j++)
                {
                    Point point = new Point(i, j);
                    if(CellCoordsInsideCircle(circle.CenterPoint, point, circle.Radius))
                    {
                        pointsInCircle.Add(point);
                    }
                }
            }
            return pointsInCircle;
        }

        /// <summary>
        /// Creates a matrix with points in circle (counts how many squares are in the circle)
        /// </summary>
        /// <param name="pointsInCircle">list of points which are in circle</param>
        /// <param name="radius">circle's radius</param>
        /// <returns>matrix with number of squares inside</returns>
        public static int[,] FillMatrix (List<Point> pointsInCircle, int radius)
        {
            int[,] circleMatrix = new int[radius * 2, radius * 2];
            for (int i = 0; i < pointsInCircle.Count; i++)
            {
                circleMatrix[pointsInCircle[i].x, pointsInCircle[i].y] = i+1; 
            }

            return circleMatrix;
        }
    }
}