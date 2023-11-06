using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPlab4
{
    /// <summary>
    /// NT office class
    /// </summary>
    public class NTOffice
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public int PhoneNumber { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">office name</param>
        /// <param name="adress">adress</param>
        /// <param name="number">phone number</param>
        public NTOffice(string name, string adress, int number)
        {
            this.Name = name;
            this.Adress = Adress;
            this.PhoneNumber = number;
        }

        /// <summary>
        /// Forms line
        /// </summary>
        /// <returns>formated line</returns>
        public override string ToString()
        {
            return String.Format("{0},{1},{2}", this.Name, this.Adress, this.PhoneNumber);
        }
    }
}