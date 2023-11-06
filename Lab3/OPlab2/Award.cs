using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPlab2
{
    /// <summary>
    /// Award object
    /// </summary>
    public class Award : IComparable<Award>, IEquatable<Award>
    {
        public List<double> AmountOfMoney { get; set; }
        public int WorkersID { get; set; }
        public List<int> InputToWork { get; set; }

        /// <summary>
        /// Object constructor
        /// </summary>
        /// <param name="amount">Amount of money for topics</param>
        /// <param name="workersID">worker's ID number</param>
        /// <param name="input">worker's input to work</param>
        public Award(List<double> amount,int workersID, List<int> input)
        {
            this.AmountOfMoney = amount;
            this.WorkersID = workersID;
            this.InputToWork = input;
        }

        /// <summary>
        /// Creates formated line of Amount of money
        /// </summary>
        /// <returns>Formated line</returns>
        public string ReturnAmountOfMoney()
        {
            string line = "";
            for (int i = 0; i < AmountOfMoney.Count; i++)
            {
                line += AmountOfMoney[i] + " ";
            }
            return line;
        }

        /// <summary>
        /// Creates formated line of Input to work
        /// </summary>
        /// <returns>Formated line</returns>
        public string ReturnInputToWork()
        {
            string line = "";
            for (int i = 0; i < InputToWork.Count; i++)
            {
                line += InputToWork[i] + " ";
            }
            return line;
        }

        /// <summary>
        /// Override ToString methos
        /// </summary>
        /// <returns>Formated line</returns>
        public override string ToString()
        {
            return string.Format("| {0, -12} | {1, -44} | ",
                this.WorkersID, ReturnInputToWork());
        }

        /// <summary>
        /// Checks if two objects are equal
        /// </summary>
        /// <param name="other">Award object</param>
        /// <returns>true if equal, otherwise false</returns>
        public bool Equals(Award other)
        {
            if (other == null) return false;
            if (this.WorkersID == other.WorkersID)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Compares two objects
        /// </summary>
        /// <param name="other">Award object</param>
        /// <returns>1 if first object is higher, -1 if lower, 0 if equal</returns>
        public int CompareTo(Award other)
        {
            if (other == null) return 1;
            return this.WorkersID.CompareTo(other.WorkersID);
        }
    }
}