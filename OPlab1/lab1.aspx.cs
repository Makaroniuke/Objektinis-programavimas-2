using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OPlab1
{
    public partial class lab1 : System.Web.UI.Page
    {
        /// <summary>
        /// Creates drop down list with numbers when page loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DropDownList1.Items.Count == 0)
            {
                DropDownList1.Items.Add("1");
                for (int i = 2; i <= 16; i++)
                {
                    DropDownList1.Items.Add(i.ToString());
                }
            }
        }

        /// <summary>
        /// Solves task with circles and prints matrix
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {           
            int radius = int.Parse(DropDownList1.Text);    

            Circle circle = new Circle(radius);
            List<Point> pointsInCircle = TaskUtils.GetSquaresInCircle(circle);

            int[,] circleMatrix = TaskUtils.FillMatrix(pointsInCircle, radius);
            FormTable(Table1, circleMatrix);
       
        }

        /// <summary>
        /// Forms the matrix
        /// </summary>
        /// <param name="table">table to print matrix</param>
        /// <param name="circleMatrix">matrix with squares in circle</param>
        public static void FormTable(Table table, int[,] circleMatrix)
        {
            int rowLength = circleMatrix.GetLength(0);
            int colLength = circleMatrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                TableRow row = new TableRow();
                for (int j = 0; j < colLength; j++)
                {
                    TableCell number = new TableCell();
                    number.Text = string.Format("{0, 2}", circleMatrix[i, j].ToString());
                    row.Cells.Add(number);
                }
                table.Rows.Add(row);
            }
        }


    }
}